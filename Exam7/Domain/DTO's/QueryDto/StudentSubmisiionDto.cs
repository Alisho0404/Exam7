using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO_s.QueryDto
{
    public class StudentSubmisiionDto
    {
        public required string StudentName { get; set; }
        public int SubmisiionCount { get; set; }
    }
}
