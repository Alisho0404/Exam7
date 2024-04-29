using AutoMapper;
using Domain.DTO_s.AssignementDTO;
using Domain.DTO_s.CourseDTO;
using Domain.DTO_s.FeedBackDTO;
using Domain.DTO_s.MaterialDTO;
using Domain.DTO_s.StudentDTO;
using Domain.DTO_s.SubmissionDTO;
using Domain.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.AutoMapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Assignment,AddAssignmentDto>().ReverseMap();
            CreateMap<Assignment,GetAssignmentDto>().ReverseMap();
            CreateMap<Assignment,UpdateAssignmentDto>().ReverseMap(); 

            CreateMap<Course,AddCourseDto>().ReverseMap();
            CreateMap<Course,GetCourseDto>().ReverseMap();
            CreateMap<Course,UpdateCourseDto>().ReverseMap();

            CreateMap<Feedback, AddFeedbackDto>().ReverseMap();
            CreateMap<Feedback, GetFeedbackDto>().ReverseMap();
            CreateMap<Feedback, UpdateFeedbackDto>().ReverseMap();

            CreateMap<Material, AddMaterialDto>().ReverseMap();
            CreateMap<Material, GetMaterialDto>().ReverseMap();
            CreateMap<Material, UpdateMaterialDto>().ReverseMap();

            CreateMap<Student, AddStudentDto>().ReverseMap();
            CreateMap<Student, GetStudentDto>().ReverseMap();
            CreateMap<Student, UpdateStudentDto>().ReverseMap();

            CreateMap<Submission, AddSubmissionDto>().ReverseMap();
            CreateMap<Submission, GetSubmissionDto>().ReverseMap();
            CreateMap<Submission, UpdateSubmissionDto>().ReverseMap();

        }
    }
}
