using Domain.DTO_s.QueryDto;
using Domain.Filters;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.QueryService
{
    public interface IQueryService
    {
        Task<PageResponse<List<StudentSubmisiionDto>>> StudentsSubmissionsAsync(SubmissionFilter filter);
        Task<PageResponse<List<StudentWithoutSubmissionDto>>> StudentsWithoutSubmissionsAsync(SubmissionFilter filter);
        Task<PageResponse<List<CourseMaterialDto>>> CourseMaterialsAsync(CourseFilter filter);
        Task<PageResponse<List<StudentwithExcellentSubmisiionDto>>> StudentswhoSubmittedOntimeAsync(StudentFilter filter);
    }
}
