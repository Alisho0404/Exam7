using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enteties
{
    public class Submission
    {
        public int Id { get; set; }
        public int AssignmentId { get; set; }
        public int StudentId { get; set; }
        public DateTime SubmisiionDate { get; set; }
        public string? Content { get; set; }
        public Assignment? Assignment { get; set; }
        public Student? Student { get; set; }
    }
}
