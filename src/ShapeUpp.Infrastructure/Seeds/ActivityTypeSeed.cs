using ShapeUpp.Domain.Models;
using System.Collections.Generic;

namespace ShapeUpp.Infrastructure.Seeds
{
    internal static class ActivityTypeSeed
    {
        internal static IEnumerable<ActivityType> GetSeed()
        {
            yield return new ActivityType(-1, "Cardio");
            yield return new ActivityType(-2, "Stretching");
            yield return new ActivityType(-3, "Body weight");
            yield return new ActivityType(-4, "Free weight");
            yield return new ActivityType(-5, "Machine");
            yield return new ActivityType(-6, "Cable");
            yield return new ActivityType(-7, "Band");
        }
    }
}
