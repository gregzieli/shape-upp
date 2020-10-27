using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShapeUpp.Domain.Models;
using ShapeUpp.Infrastructure.Seeds;

namespace ShapeUpp.Infrastructure.EntityConfigurations
{
    public class EquipmentEntityConfiguration : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.ToTable("Equipment");

            builder.Property(x => x.Name).HasMaxLength(64).IsRequired();

            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasData(EquipmentSeed.GetSeed());
        }
    }
}
