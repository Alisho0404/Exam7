using Domain.DTO_s.AssignementDTO;
using Domain.DTO_s.CourseDTO;
using Domain.Filters;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.CourseService
{
    public interface ICourseService
    {
        Task<PageResponse<List<GetCourseDto>>> GetCourseAsync(CourseFilter filter); 
        Task<PageResponse<List<GetCourseAndMaterialDto>>>GetCourseAndMaterailAsync(CourseFilter filter);
        Task<Response<GetCourseDto>> GetCourseByIdAsync(int id);
        Task<Response<string>> AddCourseAsync(AddCourseDto courseDto);
        Task<Response<string>> UpdateCourseAsync(UpdateCourseDto courseDto);
        Task<Response<bool>> DeleteCourseAsync(int id);
    }
}
