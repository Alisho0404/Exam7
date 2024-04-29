using Domain.DTO_s.CourseDTO;
using Domain.DTO_s.MaterialDTO;
using Domain.Filters;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.MaterialService
{
    public interface IMaterialService
    {
        Task<PageResponse<List<GetMaterialDto>>> GetMaterialAsync(MaterialFilter filter); 
        Task<PageResponse<List<GetMaterialForSpecCourseDto>>>GetMaterialForSpecificCourse(MaterialFilter filter);
        Task<Response<GetMaterialDto>> GetMaterialByIdAsync(int id);
        Task<Response<string>> AddMaterialAsync(AddMaterialDto materialDto);
        Task<Response<string>> UpdateMaterialAsync(UpdateMaterialDto materialDto);
        Task<Response<bool>> DeleteMaterialAsync(int id);
    }
}
