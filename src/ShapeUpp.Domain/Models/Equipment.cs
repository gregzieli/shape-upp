using System;
using System.Collections.Generic;

namespace ShapeUpp.Domain.Models
{
    public class Equipment
    {
        public Equipment(int id, string category, string name)
        {
            Id = id;
            Category = category;
            Name = name;
        }

        public int Id { get; private set; }

        public string Category { get; private set; }

        public string Name { get; private set; }

        public ICollection<Exercise> Exercises { get; set; }
    }
}
