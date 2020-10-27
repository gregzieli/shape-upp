using ShapeUpp.Domain.Constants;
using ShapeUpp.Domain.Models;
using System.Collections.Generic;

namespace ShapeUpp.Infrastructure.Seeds
{
    internal static class MuscleGroupSeed
    {
        internal static IEnumerable<MuscleGroup> GetSeed()
        {
            yield return new MuscleGroup(-1, BodyParts.Legs, "Abductors", isSecondary: true);
            yield return new MuscleGroup(-2, BodyParts.Legs, "Adductors", isSecondary: true);
            yield return new MuscleGroup(-3, BodyParts.Legs, "Calves");
            yield return new MuscleGroup(-4, BodyParts.Legs, "Hamstrings");
            yield return new MuscleGroup(-5, BodyParts.Legs, "Quadriceps");
            yield return new MuscleGroup(-6, BodyParts.Legs, "Glutes");

            yield return new MuscleGroup(-7, BodyParts.Abdominals, "Abs");
            yield return new MuscleGroup(-8, BodyParts.Abdominals, "Obliques", isSecondary: true);
            yield return new MuscleGroup(-9, BodyParts.Abdominals, "Lower abs");
            yield return new MuscleGroup(-10, BodyParts.Abdominals, "Upper abs");

            yield return new MuscleGroup(-11, BodyParts.Back, "Lats");
            yield return new MuscleGroup(-12, BodyParts.Back, "Traps");
            yield return new MuscleGroup(-13, BodyParts.Back, "Lower back");

            yield return new MuscleGroup(-14, BodyParts.Arms, "Biceps");
            yield return new MuscleGroup(-15, BodyParts.Arms, "Triceps");
            yield return new MuscleGroup(-16, BodyParts.Arms, "Forearms");

            yield return new MuscleGroup(-17, BodyParts.Chest, "Chest");
            yield return new MuscleGroup(-18, BodyParts.Chest, "Lower chest");
            yield return new MuscleGroup(-19, BodyParts.Chest, "Upper chest");

            yield return new MuscleGroup(-20, BodyParts.Shoulders, "Front delts");
            yield return new MuscleGroup(-21, BodyParts.Shoulders, "Side delts");
            yield return new MuscleGroup(-22, BodyParts.Shoulders, "Rear delts");
        }
    }
}
