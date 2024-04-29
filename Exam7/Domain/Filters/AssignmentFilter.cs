using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Filters
{
    public class AssignmentFilter:PaginationFilter
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
