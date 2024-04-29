using Domain.DTO_s.CourseDTO;
using Domain.DTO_s.SubmissionDTO;
using Domain.Filters;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.SubmissionService
{
    public interface ISubmissionService
    {
        Task<PageResponse<List<GetSubmissionDto>>> GetSubmissionAsync(SubmissionFilter filter);
        Task<Response<GetSubmissionDto>> GetSubmissionByIdAsync(int id);
        Task<Response<string>> AddSubmissionAsync(AddSubmissionDto submissionDto);
        Task<Response<string>> UpdateSubmissionAsync(UpdateSubmissionDto submissionDto);
        Task<Response<bool>> DeleteSubmissionAsync(int id);
    }
}
