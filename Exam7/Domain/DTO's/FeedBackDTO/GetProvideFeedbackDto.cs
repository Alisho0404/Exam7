using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO_s.FeedBackDTO
{
    public class GetProvideFeedbackDto
    {
        public required string  StudentName { get; set; }
        public required string AdmissionTitle { get; set; }
        public string? AdmisiionDescription { get; set; }
        public required string FeedbackText { get; set; }
        public DateTime FeedbackDate { get; set; }
       
    }
}
