using AutoMapper;
using Domain.DTO_s.CourseDTO;
using Domain.DTO_s.StudentDTO;
using Domain.Enteties;
using Domain.Filters;
using Domain.Response;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.CourseService
{
    public class CourseService : ICourseService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CourseService(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper=mapper;
        }
        public async Task<Response<string>> AddCourseAsync(AddCourseDto courseDto)
        {
            try
            {
                var findBy = await _context.Courses.FirstOrDefaultAsync(x => x.Title == courseDto.Title);
                if (findBy != null)
                {
                    return new Response<string>(HttpStatusCode.BadRequest, "Already exist");
                }
                var mapped = _mapper.Map<Course>(courseDto);

                await _context.Courses.AddAsync(mapped);
                await _context.SaveChangesAsync();
                return new Response<string>("Succesfully added");


            }
            catch (Exception e)
            {

                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<bool>> DeleteCourseAsync(int id)
        {
            try
            {
                var delete = await _context.Courses.Where(x => x.Id == id).ExecuteDeleteAsync();
                if (delete == 0)
                {
                    return new Response<bool>(HttpStatusCode.BadRequest, "Not found");
                }
                return new Response<bool>(true);
            }
            catch (Exception e)
            {

                return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<PageResponse<List<GetCourseAndMaterialDto>>> GetCourseAndMaterailAsync(CourseFilter filter)
        {
            try
            {
                var courses = await (from c in _context.Courses
                                     join m in _context.Materials on c.Id equals m.CourseId
                                     select new GetCourseAndMaterialDto
                                     {
                                         CourseName = c.Title,
                                         Description = c.Description,
                                         CourseInstructor = c.Instructor,
                                         MaterialTitle = m.Title,
                                         MaterialDescription = m.Description
                                     }).ToListAsync();
                var response = courses
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize).ToList();
                var totalRecord = courses.Count(); 
                return new PageResponse<List<GetCourseAndMaterialDto>>(response,filter.PageNumber,filter.PageSize,totalRecord);
            }
            catch (Exception e)
            {

                return new PageResponse<List<GetCourseAndMaterialDto>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<PageResponse<List<GetCourseDto>>> GetCourseAsync(CourseFilter filter)
        {
            try
            {
                var courses = _context.Courses.AsQueryable();
                if (!string.IsNullOrEmpty(filter.Description))
                {
                    courses = courses.Where(x => x.Description!.ToLower().Contains(filter.Description.ToLower()));
                }
                if (!string.IsNullOrEmpty(filter.Title))
                {
                    courses = courses.Where(x => x.Title!.Contains(filter.Title));
                }

                var response = await courses
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize).ToListAsync();
                var totalRecord = courses.Count();

                var mapped = _mapper.Map<List<GetCourseDto>>(response);

                return new PageResponse<List<GetCourseDto>>(mapped, filter.PageNumber, filter.PageSize, totalRecord);
            }
            catch (Exception e)
            {

                return new PageResponse<List<GetCourseDto>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<GetCourseDto>> GetCourseByIdAsync(int id)
        {
            try
            {
                var exist = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
                if (exist == null)
                {
                    return new Response<GetCourseDto>(HttpStatusCode.BadRequest, "Not found");
                }
                var mapped = _mapper.Map<GetCourseDto>(exist);

                return new Response<GetCourseDto>(mapped);
            }
            catch (Exception e)
            {

                return new Response<GetCourseDto>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<string>> UpdateCourseAsync(UpdateCourseDto courseDto)
        {
            try
            {
                var mapped = _mapper.Map<Course>(courseDto);
                _context.Courses.Update(mapped);

                var update = await _context.SaveChangesAsync();
                if (update == 0)
                {
                    return new Response<string>(HttpStatusCode.BadRequest, "Not found");
                }
                return new Response<string>("Succesfully updated");
            }
            catch (Exception e)
            {
                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);

            }
        }
    }
}
