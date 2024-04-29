using Domain.DTO_s.CourseDTO;
using Domain.DTO_s.FeedBackDTO;
using Domain.Filters;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.FeedBackService
{
    public interface IFeedBackService
    {
        Task<PageResponse<List<GetFeedbackDto>>> GetFeedbacksAsync(FeedbackFilter filter);
        Task<PageResponse<List<GetProvideFeedbackDto>>> GetProvideFeedbacksAsync(FeedbackFilter filter);
        Task<PageResponse<List<GetFeedbackForAssignmentDto>>>GetFeedBacksForAssignment(FeedbackFilter filter);
        Task<Response<GetFeedbackDto>> GetFeedbackByIdAsync(int id);
        Task<Response<string>> AddFeedbackAsync(AddFeedbackDto feedbackDto);
        Task<Response<string>> UpdateFeedbackAsync(UpdateFeedbackDto feedbackDto);
        Task<Response<bool>> DeleteFeedbackAsync(int id);
    }
}
