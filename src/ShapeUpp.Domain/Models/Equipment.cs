using System;

namespace ShapeUpp.Domain.Models
{
    public class Equipment
    {
        public Equipment(string category, string name)
        {
            Id = Guid.NewGuid();
            Category = category;
            Name = name;
        }

        public Guid Id { get; private set; }

        public string Category { get; private set; }

        public string Name { get; private set; }
    }
}
