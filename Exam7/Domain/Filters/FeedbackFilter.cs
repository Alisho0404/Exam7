using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Filters
{
    public class FeedbackFilter:PaginationFilter
    {
        public string Text { get; set; } = null!;
    }
}
