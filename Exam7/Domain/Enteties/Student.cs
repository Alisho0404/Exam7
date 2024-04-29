using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enteties
{
    public class Student
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Email { get; set; }
        public DateTime EnrollmentDate { get; set; } 
        public  List<Feedback>? Feedbacks { get; set; } 
        public  List<Submission>? Submissions { get; set;}
    }
}
