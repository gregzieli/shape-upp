using ShapeUpp.Domain.Constants;
using ShapeUpp.Domain.Models;
using System.Collections.Generic;

namespace ShapeUpp.Infrastructure.Seeds
{
    internal static class EquipmentSeed
    {
        internal static IEnumerable<Equipment> GetSeed()
        {
            yield return new Equipment(EquipmentCategories.Barbell, "EZ bar");
            yield return new Equipment(EquipmentCategories.Barbell, "Regular bar");
            yield return new Equipment(EquipmentCategories.Barbell, "Olympic bar");
            yield return new Equipment(EquipmentCategories.Dumbbell, "Dumbbell");
            yield return new Equipment(EquipmentCategories.Kettlebell, "Kettlebell");
            yield return new Equipment(EquipmentCategories.Bench, "Flat bench");
            yield return new Equipment(EquipmentCategories.Bench, "Inclined bench");
            yield return new Equipment(EquipmentCategories.Bench, "Declined bench");
            yield return new Equipment(EquipmentCategories.Machine, "Smith machine");
            yield return new Equipment(EquipmentCategories.Accessory, "Rope");
        }
    }
}
