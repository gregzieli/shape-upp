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
            builder.ToTable("ActivityTypes");

            builder.Property(x => x.Name).HasMaxLength(64).IsRequired();

            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasData(ActivityTypeSeed.GetSeed());
        }
    }
}
