using System.Collections.Generic;

namespace ShapeUpp.Domain.Models
{
    public class Exercise
    {
        public int Id { get; private set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public ActivityType Category { get; set; }

        public ICollection<MuscleGroup> MuscleGroups { get; set; }

        public ICollection<Equipment> Equipment { get; set; }
    }
}
