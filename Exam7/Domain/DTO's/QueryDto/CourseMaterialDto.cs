using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO_s.QueryDto
{
    public class CourseMaterialDto
    {
        public required string  CourseName { get; set; }
        public int MaterialCount { get; set; }
    }
}
