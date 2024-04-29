using Domain.DTO_s.CourseDTO;
using Domain.DTO_s.StudentDTO;
using Domain.Filters;
using Domain.Response;
using Infrastructure.Services.StudentService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentController:ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<Response<List<GetStudentDto>>> GetStudentsAsync(StudentFilter filter)
        {
            return await _studentService.GetStudentAsync(filter);
        }

        [HttpGet("{id:int}")]
        public async Task<Response<GetStudentDto>> GetStudentByIdAsync(int id)
        {
            return await _studentService.GetStudentByIdAsync(id);
        }

        [HttpPost]
        public async Task<Response<string>> AddStudentAsync(AddStudentDto studentDto)
        {
            return await _studentService.AddStudentAsync(studentDto);
        }

        [HttpPut]
        public async Task<Response<string>> UpdatCourseAsync(UpdateStudentDto studentDto)
        {
            return await _studentService.UpdateStudentAsync(studentDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<Response<bool>> DeleteStudentAsync(int id)
        {
            return await _studentService.DeleteStudentAsync(id);
        }
    }
}
