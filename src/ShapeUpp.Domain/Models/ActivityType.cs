using System;

namespace ShapeUpp.Domain.Models
{
    public class ActivityType
    {
        public ActivityType(Guid id)
        {
            Id = id;
        }

        public ActivityType(string name, string description = default)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }
    }
}
