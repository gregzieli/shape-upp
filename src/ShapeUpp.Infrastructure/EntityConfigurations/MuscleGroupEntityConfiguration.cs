using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShapeUpp.Domain.Constants;
using ShapeUpp.Domain.Models;
using ShapeUpp.Infrastructure.Seeds;
using System;

namespace ShapeUpp.Infrastructure.EntityConfigurations
{
    public class MuscleGroupEntityConfiguration : IEntityTypeConfiguration<MuscleGroup>
    {
        public void Configure(EntityTypeBuilder<MuscleGroup> builder)
        {
            builder.ToContainer("Muscles");

            builder.HasNoDiscriminator();

            builder.HasPartitionKey(x => x.BodyPart);

            builder.HasIndex(x => x.Name);

            builder.Property(x => x.Id).ToJsonProperty("id");

            builder.Property(x => x.BodyPart).HasConversion(
                x => x.ToString(),
                x => (BodyParts)Enum.Parse(typeof(BodyParts), x));

            builder.HasData(MuscleGroupSeed.GetSeed());
        }
    }
}
