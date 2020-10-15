using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShapeUpp.Domain.Models;

namespace ShapeUpp.Infrastructure.EntityConfigurations
{
    public class ExerciseEntityConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.ToContainer("Exercises");

            builder.HasNoDiscriminator();

            builder.Property(x => x.Id).ToJsonProperty("id");

            builder.HasOne(x => x.Category).WithMany();
            builder.HasMany(x => x.MuscleGroups).WithOne();
            builder.HasMany(x => x.Equipment).WithOne();

            builder.OwnsMany(x => x.MuscleIds).WithOwner();
            builder.OwnsMany(x => x.EquipmentIds).WithOwner();
        }
    }
}
