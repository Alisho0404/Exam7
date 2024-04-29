using Domain.DTO_s.CourseDTO;
using Domain.DTO_s.FeedBackDTO;
using Domain.Filters;
using Domain.Response;
using Infrastructure.Services.FeedBackService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/feedbacks")]
    public class FeedbackController:ControllerBase
    {
        private readonly IFeedBackService _feedbackService;
        public FeedbackController(IFeedBackService feedBackService)
        {
            _feedbackService = feedBackService;
        }

        [HttpGet]
        public async Task<Response<List<GetFeedbackDto>>> GetFeedbacksAsync(FeedbackFilter filter)
        {
            return await _feedbackService.GetFeedbacksAsync(filter);
        }

        [HttpGet("Provide feedback")]
        public async Task<PageResponse<List<GetProvideFeedbackDto>>>GetProvideFeedBackAsync(FeedbackFilter filter)
        {
            return await _feedbackService.GetProvideFeedbacksAsync(filter);
        }

        [HttpGet("Assignment feedback")]
        public async Task<PageResponse<List<GetFeedbackForAssignmentDto>>> GeFeedBackForAssignmentAsync(FeedbackFilter filter)
        {
            return await _feedbackService.GetFeedBacksForAssignment(filter);
        }


            [HttpGet("{id:int}")]
        public async Task<Response<GetFeedbackDto>> GetFeedbackByIdAsync(int id)
        {
            return await _feedbackService.GetFeedbackByIdAsync(id);
        }

        [HttpPost]
        public async Task<Response<string>> AddFeedbackAsync(AddFeedbackDto feedbackDto)
        {
            return await _feedbackService.AddFeedbackAsync(feedbackDto);
        }

        [HttpPut]
        public async Task<Response<string>> UpdatFeedbackAsync(UpdateFeedbackDto feedbackDto)
        {
            return await _feedbackService.UpdateFeedbackAsync(feedbackDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<Response<bool>> DeleteFeedbackAsync(int id)
        {
            return await _feedbackService.DeleteFeedbackAsync(id);
        }
    }
}
