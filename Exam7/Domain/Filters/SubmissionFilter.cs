﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Filters
{
    public class SubmissionFilter:PaginationFilter
    {
        public string Content { get; set; } = null!;
    }
}
