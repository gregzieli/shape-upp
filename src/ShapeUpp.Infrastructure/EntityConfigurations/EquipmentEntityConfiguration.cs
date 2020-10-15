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
            builder.ToContainer("Equipment");

            builder.HasNoDiscriminator();

            builder.HasPartitionKey(x => x.Category);

            builder.HasIndex(x => x.Name);

            builder.Property(x => x.Id).ToJsonProperty("id");

            builder.HasData(EquipmentSeed.GetSeed());
        }
    }
}
