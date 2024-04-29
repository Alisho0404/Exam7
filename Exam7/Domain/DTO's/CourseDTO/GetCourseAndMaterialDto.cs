using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO_s.CourseDTO
{
    public class GetCourseAndMaterialDto
    {
        public required string CourseName { get; set; }        
        public string? Description { get; set; }
        public  string? CourseInstructor { get; set; }
        public string? MaterialTitle { get; set; }
        public string? MaterialDescription { get; set; }
    }
}
