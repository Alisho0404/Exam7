using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO_s.FeedBackDTO
{
    public class GetFeedbackForAssignmentDto
    {
        public required string AssignmentTitle { get; set; }
        public string? AssignmentDescription { get; set; }
        public DateTime AssignmentDueDate { get; set; }
        public required string Feedback { get; set; }

    }
}
