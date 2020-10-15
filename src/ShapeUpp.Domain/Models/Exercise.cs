using System;
using System.Collections.Generic;

namespace ShapeUpp.Domain.Models
{
    public class Exercise
    {
        public Exercise() {}

        public Exercise(string name)
        {
            Name = name;
        }

        public Guid Id { get; private set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ActivityType Category { get; set; }

        public ICollection<MuscleGroup> MuscleGroups { get; set; }

        public ICollection<Equipment> Equipment { get; set; }

        public ICollection<MuscleId> MuscleIds { get; set; }

        public ICollection<EquipmentId> EquipmentIds { get; set; }
    }

    public class MuscleId
    {
        public Guid Id { get; set; }
    }

    public class EquipmentId
    {
        public Guid Id { get; set; }
    }
}
