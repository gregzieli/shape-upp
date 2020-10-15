using ShapeUpp.Domain.Models;
using System.Collections.Generic;

namespace ShapeUpp.Infrastructure.Seeds
{
    internal static class ActivityTypeSeed
    {
        internal static IEnumerable<ActivityType> GetSeed()
        {
            yield return new ActivityType("Cardio");
            yield return new ActivityType("Stretching");
            yield return new ActivityType("Body weight");
            yield return new ActivityType("Free weight");
            yield return new ActivityType("Machine");
            yield return new ActivityType("Cable");
            yield return new ActivityType("Band");
        }
    }
}
