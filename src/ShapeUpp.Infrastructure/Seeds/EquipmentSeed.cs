using ShapeUpp.Domain.Constants;
using ShapeUpp.Domain.Models;
using System.Collections.Generic;

namespace ShapeUpp.Infrastructure.Seeds
{
    internal static class EquipmentSeed
    {
        internal static IEnumerable<Equipment> GetSeed()
        {
            yield return new Equipment(-1, EquipmentCategories.Barbell, "EZ bar");
            yield return new Equipment(-2, EquipmentCategories.Barbell, "Regular bar");
            yield return new Equipment(-3, EquipmentCategories.Barbell, "Olympic bar");
            yield return new Equipment(-4, EquipmentCategories.Dumbbell, "Dumbbell");
            yield return new Equipment(-5, EquipmentCategories.Kettlebell, "Kettlebell");
            yield return new Equipment(-6, EquipmentCategories.Bench, "Flat bench");
            yield return new Equipment(-7, EquipmentCategories.Bench, "Inclined bench");
            yield return new Equipment(-8, EquipmentCategories.Bench, "Declined bench");
            yield return new Equipment(-9, EquipmentCategories.Machine, "Smith machine");
            yield return new Equipment(-10, EquipmentCategories.Accessory, "Rope");
        }
    }
}
