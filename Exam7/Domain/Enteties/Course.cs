using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enteties
{
    public class Course
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required string Instructor { get; set; }
        public int Credits { get; set; }
        public List<Material>? Materials { get; set; }
        public List<Assignment>? Assignments { get; set; }
    }
}
