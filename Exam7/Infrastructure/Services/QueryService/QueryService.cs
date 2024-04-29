using AutoMapper;
using Domain.DTO_s.QueryDto;
using Domain.Filters;
using Domain.Response;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enteties;

namespace Infrastructure.Services.QueryService
{
    public class QueryService : IQueryService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public QueryService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PageResponse<List<CourseMaterialDto>>> CourseMaterialsAsync(CourseFilter filter)
        {
            try
            {
                var courses = await (from c in _context.Courses
                                     join m in _context.Materials on c.Id equals m.CourseId
                                     let count = _context.Materials.Count(x => x.CourseId == c.Id)
                                     select new CourseMaterialDto
                                     {
                                         CourseName = c.Title,
                                         MaterialCount = count
                                     }
                                     ).ToListAsync();
                var response = courses
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize).ToList();
                var totalRecord = response.Count();
                return new PageResponse<List<CourseMaterialDto>>(response, filter.PageNumber, filter.PageSize, totalRecord);

            }
            catch (Exception e)
            {

                return new PageResponse<List<CourseMaterialDto>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<PageResponse<List<StudentSubmisiionDto>>> StudentsSubmissionsAsync(SubmissionFilter filter)
        {
            try
            {
                var students = await (from st in _context.Students
                                      join s in _context.Submissions on st.Id equals s.StudentId
                                      let count = _context.Submissions.Count(x => x.StudentId == st.Id)
                                      select new StudentSubmisiionDto
                                      {
                                          StudentName = st.Name,
                                          SubmisiionCount = count

                                      }
                ).ToListAsync();
                var response = students
                   .Skip((filter.PageNumber - 1) * filter.PageSize)
                   .Take(filter.PageSize).ToList();
                var totalRecord = response.Count();
                return new PageResponse<List<StudentSubmisiionDto>>(response, filter.PageNumber, filter.PageSize, totalRecord);


            }
            catch (Exception e)
            {

                return new PageResponse<List<StudentSubmisiionDto>>(HttpStatusCode.InternalServerError, e.Message);
            }

        }

        public async Task<PageResponse<List<StudentwithExcellentSubmisiionDto>>> StudentswhoSubmittedOntimeAsync(StudentFilter filter)
        {
            try
            {
                var studentho = await (from st in _context.Students
                                       join s in _context.Submissions on st.Id equals s.StudentId
                                       join a in _context.Assignments on s.AssignmentId equals a.Id
                                       where s.SubmisiionDate < a.DueDate
                                       select new StudentwithExcellentSubmisiionDto
                                       {
                                           StudentName = st.Name
                                       }
                ).ToListAsync();
                var response = studentho
                  .Skip((filter.PageNumber - 1) * filter.PageSize)
                  .Take(filter.PageSize).ToList();
                var totalRecord = response.Count();
                return new PageResponse<List<StudentwithExcellentSubmisiionDto>>(response, filter.PageNumber, filter.PageSize, totalRecord);
            }
            catch (Exception e)
            {

                return new PageResponse<List<StudentwithExcellentSubmisiionDto>>(HttpStatusCode.InternalServerError, e.Message);
            }

        }

        public async Task<PageResponse<List<StudentWithoutSubmissionDto>>> StudentsWithoutSubmissionsAsync(SubmissionFilter filter)
        {
            try
            {
                var studenti = await (from st in _context.Students
                                join s in _context.Submissions on st.Id equals s.StudentId
                                let count = _context.Submissions.Count(x => x.StudentId == s.Id)
                                where count < 0
                                select new StudentWithoutSubmissionDto
                                {
                                    StudentName = st.Name
                                }
                ).ToListAsync();
                var response = studenti
                  .Skip((filter.PageNumber - 1) * filter.PageSize)
                  .Take(filter.PageSize).ToList();
                var totalRecord = response.Count();
                return new PageResponse<List<StudentWithoutSubmissionDto>>(response, filter.PageNumber, filter.PageSize, totalRecord);
            }
            catch (Exception e)
            {

                return new PageResponse<List<StudentWithoutSubmissionDto>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
