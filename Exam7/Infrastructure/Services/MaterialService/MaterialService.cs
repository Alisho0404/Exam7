using AutoMapper;
using Domain.DTO_s.MaterialDTO;
using Domain.DTO_s.StudentDTO;
using Domain.Enteties;
using Domain.Filters;
using Domain.Response;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.MaterialService
{
    public class MaterialService : IMaterialService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public MaterialService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Response<string>> AddMaterialAsync(AddMaterialDto materialDto)
        {
            try
            {

                var mapped = _mapper.Map<Material>(materialDto);

                await _context.Materials.AddAsync(mapped);
                await _context.SaveChangesAsync();
                return new Response<string>("Succesfully added");


            }
            catch (Exception e)
            {

                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<bool>> DeleteMaterialAsync(int id)
        {
            try
            {
                var delete = await _context.Materials.Where(x => x.Id == id).ExecuteDeleteAsync();
                if (delete == 0)
                {
                    return new Response<bool>(HttpStatusCode.BadRequest, "Not found");
                }
                return new Response<bool>(true);
            }
            catch (Exception e)
            {

                return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<PageResponse<List<GetMaterialDto>>> GetMaterialAsync(MaterialFilter filter)
        {
            try
            {
                var materials = _context.Materials.AsQueryable();
                if (!string.IsNullOrEmpty(filter.Title))
                {
                    materials = materials.Where(x => x.Title!.ToLower().Contains(filter.Title.ToLower()));
                }
                if (!string.IsNullOrEmpty(filter.Description))
                {
                    materials = materials.Where(x => x.Description!.ToLower().Contains(filter.Description.ToLower()));
                }

                var response = await materials
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize).ToListAsync();
                var totalRecord = materials.Count();

                var mapped = _mapper.Map<List<GetMaterialDto>>(response);

                return new PageResponse<List<GetMaterialDto>>(mapped, filter.PageNumber, filter.PageSize, totalRecord);
            }
            catch (Exception e)
            {

                return new PageResponse<List<GetMaterialDto>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<GetMaterialDto>> GetMaterialByIdAsync(int id)
        {
            try
            {
                var exist = await _context.Materials.FirstOrDefaultAsync(x => x.Id == id);
                if (exist == null)
                {
                    return new Response<GetMaterialDto>(HttpStatusCode.BadRequest, "Not found");
                }
                var mapped = _mapper.Map<GetMaterialDto>(exist);

                return new Response<GetMaterialDto>(mapped);
            }
            catch (Exception e)
            {

                return new Response<GetMaterialDto>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<PageResponse<List<GetMaterialForSpecCourseDto>>> GetMaterialForSpecificCourse(MaterialFilter filter)
        {
            try
            {
                string course = "CourseName";
                var materials = await (from m in _context.Materials
                                       join c in _context.Courses on m.CourseId equals c.Id
                                       where c.Title == course
                                       select new GetMaterialForSpecCourseDto
                                       {
                                           Title = m.Title,
                                           Description = m.Description,
                                           ContentUrl = m.ContentUrl
                                       }).ToListAsync();

                var response = materials
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize).ToList();
                var totalRecord = materials.Count();
                return new PageResponse<List<GetMaterialForSpecCourseDto>>(response, filter.PageNumber, filter.PageSize, totalRecord);

            }
            catch (Exception e)
            {

                return new PageResponse<List<GetMaterialForSpecCourseDto>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<string>> UpdateMaterialAsync(UpdateMaterialDto materialDto)
        {
            try
            {
                var mapped = _mapper.Map<Material>(materialDto);
                _context.Materials.Update(mapped);

                var update = await _context.SaveChangesAsync();
                if (update == 0)
                {
                    return new Response<string>(HttpStatusCode.BadRequest, "Not found");
                }
                return new Response<string>("Succesfully updated");
            }
            catch (Exception e)
            {
                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);

            }
        }
    }
}
