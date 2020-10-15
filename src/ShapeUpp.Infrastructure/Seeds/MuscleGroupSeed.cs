using ShapeUpp.Domain.Constants;
using ShapeUpp.Domain.Models;
using System.Collections.Generic;

namespace ShapeUpp.Infrastructure.Seeds
{
    internal static class MuscleGroupSeed
    {
        internal static IEnumerable<MuscleGroup> GetSeed()
        {
            yield return new MuscleGroup(BodyParts.Legs, "Abductors", isSecondary: true);
            yield return new MuscleGroup(BodyParts.Legs, "Adductors", isSecondary: true);
            yield return new MuscleGroup(BodyParts.Legs, "Calves");
            yield return new MuscleGroup(BodyParts.Legs, "Hamstrings");
            yield return new MuscleGroup(BodyParts.Legs, "Quadriceps");
            yield return new MuscleGroup(BodyParts.Legs, "Glutes");

            yield return new MuscleGroup(BodyParts.Abdominals, "Abs");
            yield return new MuscleGroup(BodyParts.Abdominals, "Obliques", isSecondary: true);
            yield return new MuscleGroup(BodyParts.Abdominals, "Lower abs");
            yield return new MuscleGroup(BodyParts.Abdominals, "Upper abs");

            yield return new MuscleGroup(BodyParts.Back, "Lats");
            yield return new MuscleGroup(BodyParts.Back, "Traps");
            yield return new MuscleGroup(BodyParts.Back, "Lower back");

            yield return new MuscleGroup(BodyParts.Arms, "Biceps");
            yield return new MuscleGroup(BodyParts.Arms, "Triceps");
            yield return new MuscleGroup(BodyParts.Arms, "Forearms");

            yield return new MuscleGroup(BodyParts.Chest, "Chest");
            yield return new MuscleGroup(BodyParts.Chest, "Lower chest");
            yield return new MuscleGroup(BodyParts.Chest, "Upper chest");

            yield return new MuscleGroup(BodyParts.Shoulders, "Front delts");
            yield return new MuscleGroup(BodyParts.Shoulders, "Side delts");
            yield return new MuscleGroup(BodyParts.Shoulders, "Rear delts");
        }
    }
}
