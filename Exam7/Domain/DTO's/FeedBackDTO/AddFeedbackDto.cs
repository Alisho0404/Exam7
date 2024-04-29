using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO_s.FeedBackDTO
{
    public class AddFeedbackDto
    {
      
        public int AssignmentId { get; set; }
        public int StudentId { get; set; }
        public string? Text { get; set; }
        public DateTime FeedBackDate { get; set; }
    }
}
