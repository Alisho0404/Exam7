using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO_s.StudentDTO
{
    public class AddStudentDto
    {        
        public required string Name { get; set; }
        public string? Email { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
