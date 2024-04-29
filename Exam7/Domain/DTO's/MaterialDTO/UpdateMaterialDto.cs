using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO_s.MaterialDTO
{
    public class UpdateMaterialDto
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ContentUrl { get; set; }
    }
}
