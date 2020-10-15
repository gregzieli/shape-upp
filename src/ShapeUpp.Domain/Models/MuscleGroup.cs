using ShapeUpp.Domain.Constants;
using System;

namespace ShapeUpp.Domain.Models
{
    public class MuscleGroup
    {
        public MuscleGroup(BodyParts bodyPart, string name, bool isSecondary = default)
        {
            Id = Guid.NewGuid();
            Name = name;
            BodyPart = bodyPart;
            IsSecondary = isSecondary;
        }

        public Guid Id { get; private set; }

        public BodyParts BodyPart { get; private set; }

        public string Name { get; private set; }

        public string FullName { get; set; }

        public bool IsSecondary { get; private set; }
    }
}
