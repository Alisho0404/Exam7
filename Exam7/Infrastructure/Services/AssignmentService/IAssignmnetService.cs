using Domain.DTO_s.AssignementDTO;
using Domain.Filters;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.AssignmentService
{
    public interface IAssignmnetService
    { 
        Task<PageResponse<List<GetAssignmentDto>>>GetAssignmentAsync(AssignmentFilter filter);
        Task<Response<GetAssignmentDto>> GetAssignmentByIdAsync(int id); 
        Task<Response<string>>AddAssignmentAsync(AddAssignmentDto assignmentDto); 
        Task<Response<string>>UpdateAssignmentAsync(UpdateAssignmentDto assignmentDto);
        Task<Response<bool>>DeleteAssignmentAsync(int id);
    }
}
