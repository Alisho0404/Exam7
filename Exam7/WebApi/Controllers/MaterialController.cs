using Domain.DTO_s.CourseDTO;
using Domain.DTO_s.MaterialDTO;
using Domain.Filters;
using Domain.Response;
using Infrastructure.Services.MaterialService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/materials")]
    public class MaterialController:ControllerBase
    {
        private readonly IMaterialService _materialService;
        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpGet]
        public async Task<Response<List<GetMaterialDto>>> GetMaterialsAsync(MaterialFilter filter)
        {
            return await _materialService.GetMaterialAsync(filter);
        }

        [HttpGet("{id:int}")]
        public async Task<Response<GetMaterialDto>> GetMaterialByIdAsync(int id)
        {
            return await _materialService.GetMaterialByIdAsync(id);
        }

        [HttpPost]
        public async Task<Response<string>> AddMaterialAsync(AddMaterialDto materialDto)
        {
            return await _materialService.AddMaterialAsync(materialDto);
        }

        [HttpPut]
        public async Task<Response<string>> UpdatMaterialAsync(UpdateMaterialDto materialDto)
        {
            return await _materialService.UpdateMaterialAsync(materialDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<Response<bool>> DeleteMaterialAsync(int id)
        {
            return await _materialService.DeleteMaterialAsync(id);
        }
    }
}
