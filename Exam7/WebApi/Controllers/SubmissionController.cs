using Domain.DTO_s.SubmissionDTO;
using Domain.Filters;
using Domain.Response;
using Infrastructure.Services.SubmissionService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/submissions")]
    public class SubmissionController : ControllerBase
    {
        private readonly ISubmissionService _submissionService;
        public SubmissionController(ISubmissionService submissionService)
        {
            _submissionService = submissionService;
        }

        [HttpGet]
        public async Task<Response<List<GetSubmissionDto>>> GetSubmissionsAsync(SubmissionFilter filter)
        {
            return await _submissionService.GetSubmissionAsync(filter);
        }

        [HttpGet("{id:int}")]
        public async Task<Response<GetSubmissionDto>> GetSubmissionByIdAsync(int id)
        {
            return await _submissionService.GetSubmissionByIdAsync(id);
        }

        [HttpPost]
        public async Task<Response<string>> AddSubmissionAsync(AddSubmissionDto submissionDto)
        {
            return await _submissionService.AddSubmissionAsync(submissionDto);
        }

        [HttpPut]
        public async Task<Response<string>> UpdateSubmissonAsync(UpdateSubmissionDto submissionDto)
        {
            return await _submissionService.UpdateSubmissionAsync(submissionDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<Response<bool>>DeleteSubmissionAsync(int id)
        {
            return await _submissionService.DeleteSubmissionAsync(id);
        }

    }
}
