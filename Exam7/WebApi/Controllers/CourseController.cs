using Domain.DTO_s.CourseDTO;
using Domain.DTO_s.SubmissionDTO;
using Domain.Filters;
using Domain.Response;
using Infrastructure.Services.CourseService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/course")]
    public class CourseController:ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<Response<List<GetCourseDto>>> GetCoursesAsync(CourseFilter filter)
        {
            return await _courseService.GetCourseAsync(filter);
        }

        [HttpGet("{id:int}")]
        public async Task<Response<GetCourseDto>> GetCourseByIdAsync(int id)
        {
            return await _courseService.GetCourseByIdAsync(id);
        }

        [HttpPost]
        public async Task<Response<string>> AddCourseAsync(AddCourseDto courseDto)
        {
            return await _courseService.AddCourseAsync(courseDto);
        }

        [HttpPut]
        public async Task<Response<string>> UpdatCourseAsync(UpdateCourseDto courseDto)
        {
            return await _courseService.UpdateCourseAsync(courseDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<Response<bool>> DeleteCourseAsync(int id)
        {
            return await _courseService.DeleteCourseAsync(id);
        }
    }
}
