using ShapeUpp.Domain.Constants;
using System.Collections.Generic;

namespace ShapeUpp.Domain.Models
{
    public class MuscleGroup
    {
        public MuscleGroup(int id, BodyParts bodyPart, string name, bool isSecondary = default)
        {
            Id = id;
            Name = name;
            BodyPart = bodyPart;
            IsSecondary = isSecondary;
        }

        public int Id { get; private set; }

        public BodyParts BodyPart { get; private set; }

        public string Name { get; private set; }

        public string FullName { get; set; }

        public bool IsSecondary { get; private set; }

        public ICollection<Exercise> Exercises { get; set; }
    }
}
