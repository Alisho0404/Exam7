﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Filters
{
    public class MaterialFilter : PaginationFilter
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
