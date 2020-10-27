using System.Collections.Generic;

namespace ShapeUpp.Api.Models
{
    public class ExerciseDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Activity { get; set; }

        public IEnumerable<int> Muscles { get; set; }

        public IEnumerable<int> Equipment { get; set; }
    }
}
