using Domain.DTO_s.QueryDto;
using Domain.DTO_s.StudentDTO;
using Domain.Filters;
using Domain.Response;
using Infrastructure.Services.QueryService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/queriServices")]
    public class QueryServiceController
    {
        private readonly IQueryService _queryService;
        public QueryServiceController(IQueryService queryService)
        {
            _queryService=queryService;
        } 

        [HttpGet("Cours material")]
        public async Task<PageResponse<List<CourseMaterialDto>>>GetCourseWitjMaterialCount(CourseFilter filter)
        {
            return await _queryService.CourseMaterialsAsync(filter);
        }

        [HttpGet("Student submission")]
        public async Task<PageResponse<List<StudentSubmisiionDto>>>GetStudentWithSubmission(SubmissionFilter filter)
        {
            return await _queryService.StudentsSubmissionsAsync(filter);
        }

        [HttpGet("Student who have submitted on time")] 
        public async Task<PageResponse<List<StudentwithExcellentSubmisiionDto>>>GetStudentwhoHaveSubmiitedOntiomeAsync(StudentFilter filter)
        {
            return await _queryService.StudentswhoSubmittedOntimeAsync(filter);
        }

        [HttpGet("")] 
        public async Task<PageResponse<List<StudentWithoutSubmissionDto>>>GetStudentWithoutSubmissionAsync(SubmissionFilter filter)
        {
            return await _queryService.StudentsWithoutSubmissionsAsync(filter);
        }

            
    }
}
