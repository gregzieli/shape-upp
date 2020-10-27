using System.Collections.Generic;

namespace ShapeUpp.Domain.Models
{
    public class ActivityType
    {
        public ActivityType(int id, string name, string description = default)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public ICollection<Exercise> Exercises { get; set; }
    }
}
