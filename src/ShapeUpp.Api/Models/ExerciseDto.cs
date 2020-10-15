using System;
using System.Collections.Generic;

namespace ShapeUpp.Api.Models
{
    public class ExerciseDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid Activity { get; set; }

        public IEnumerable<Guid> Muscles { get; set; }

        public IEnumerable<Guid> Equipment { get; set; }
    }
}
