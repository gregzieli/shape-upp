using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShapeUpp.Domain.Models;
using System;

namespace ShapeUpp.Infrastructure.EntityConfigurations
{
    public class ExerciseEntityConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.ToTable("Exercises");

            builder.HasOne(x => x.Category).WithMany(x => x.Exercises).HasForeignKey(x => x.CategoryId);

            builder.HasMany(x => x.MuscleGroups).WithMany(x => x.Exercises).UsingEntity(x => x.ToTable("ExerciseMuscles"));

            builder.HasMany(x => x.Equipment).WithMany(x => x.Exercises).UsingEntity(x => x.ToTable("ExerciseEquipment"));

            builder.Property<DateTimeOffset>("Created").HasDefaultValueSql("GETDATE()");
        }
    }
}
