using Domain.DTO_s.AssignementDTO;
using Domain.DTO_s.SubmissionDTO;
using Domain.Filters;
using Domain.Response;
using Infrastructure.Services.AssignmentService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/assignment")]
    public class AssignmentController:ControllerBase
    {
        private readonly IAssignmnetService _assignmentService;
        public AssignmentController(IAssignmnetService assignmnetService)
        {
            _assignmentService = assignmnetService;
        }

        [HttpGet]
        public async Task<Response<List<GetAssignmentDto>>> GetSubmissionsAsync(AssignmentFilter filter)
        {
            return await _assignmentService.GetAssignmentAsync(filter);
        }

        [HttpGet("{id:int}")]
        public async Task<Response<GetAssignmentDto>> GetAssignmentByIdAsync(int id)
        {
            return await _assignmentService.GetAssignmentByIdAsync(id);
        }

        [HttpPost]
        public async Task<Response<string>> AddAssignmentAsync(AddAssignmentDto assignmentDto)
        {
            return await _assignmentService.AddAssignmentAsync(assignmentDto);
        }

        [HttpPut]
        public async Task<Response<string>> UpdatAssignmentAsync(UpdateAssignmentDto AssignmentDto)
        {
            return await _assignmentService.UpdateAssignmentAsync(AssignmentDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<Response<bool>> DeleteAssignmentAsync(int id)
        {
            return await _assignmentService.DeleteAssignmentAsync(id);
        }

    }
}
