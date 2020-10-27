using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using ShapeUpp.Infrastructure;
using System;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShapeUpp
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IWebHostEnvironment Environment { get; }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer();

            ConfigureStorage(services);

            services.AddAutoMapper(typeof(Startup));

            services.AddResponseCaching();

            services.AddHealthChecks();

            services
                .AddControllers()
                .AddJsonOptions(builder =>
                {
                    // System.Text.Json doesn't have ReferenceLoopHandling yet.
                    // Use NewtonSoft.Json AddNewtonsoftJson or return ViewModels from the API!
                    builder.JsonSerializerOptions.IgnoreNullValues = true;
                    builder.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ActivityContext db)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            db.Database.EnsureCreated();
            //db.Database.Migrate(); // use this instead to use migrations

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Exercise API v1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseResponseCaching();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/healthcheck", new HealthCheckOptions { ResponseWriter = HealthResponse });
            });
        }

        private void ConfigureStorage(IServiceCollection services)
        {
            services.AddDbContextPool<ActivityContext>(optionsBuilder =>
            {
                optionsBuilder.ConfigureWarnings(builder =>
                {
                    builder.Default(WarningBehavior.Log);
                });

                if (Environment.IsDevelopment())
                {
                    optionsBuilder.EnableSensitiveDataLogging();
                }

                optionsBuilder.UseSqlServer(
                    Configuration.GetConnectionString("ShapeUpp"), db => db.MigrationsAssembly("ShapeUpp.Infrastructure"));
            });
        }

        private static Task HealthResponse(HttpContext context, HealthReport result)
        {
            context.Response.ContentType = "text/plain; charset=utf-8";

            var assembly = Assembly.GetEntryAssembly();
            var informationVersion = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
            var response = $"Status: {result.Status} | {System.Environment.MachineName} {assembly.GetName().Name} | v{informationVersion}";

            return context.Response.WriteAsync(response);
        }
    }
}
