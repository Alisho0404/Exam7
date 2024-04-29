﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO_s.CourseDTO
{
    public class AddCourseDto
    {

        public required string Title { get; set; }
        public string? Description { get; set; }
        public required string Instructor { get; set; }
        public int Credits { get; set; }
    }
}
