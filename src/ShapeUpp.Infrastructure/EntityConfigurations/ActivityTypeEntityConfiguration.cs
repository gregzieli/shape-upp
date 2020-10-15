using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShapeUpp.Domain.Models;
using ShapeUpp.Infrastructure.Seeds;

namespace ShapeUpp.Infrastructure.EntityConfigurations
{
    public class ActivityTypeEntityConfiguration : IEntityTypeConfiguration<ActivityType>
    {
        public void Configure(EntityTypeBuilder<ActivityType> builder)
        {
            builder.ToContainer("ActivityTypes");

            builder.HasNoDiscriminator();

            builder.Property(x => x.Id).ToJsonProperty("id");

            builder.Property(x => x.Name).IsRequired();

            builder.HasData(ActivityTypeSeed.GetSeed());
        }
    }
}
