using AutoMapper;
using Domain.DTO_s.AssignementDTO;
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

namespace Infrastructure.Services.AssignmentService
{
    public class AssignmnetService : IAssignmnetService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public AssignmnetService(DataContext context,IMapper mapper)
        {
            _context = context; 
            _mapper = mapper;
        }
        public async Task<Response<string>> AddAssignmentAsync(AddAssignmentDto assignmentDto)
        {
            try
            {
                var mapped = _mapper.Map<Assignment>(assignmentDto);

                await _context.Assignments.AddAsync(mapped);
                await _context.SaveChangesAsync();
                return new Response<string>("Succesfully added");


            }
            catch (Exception e)
            {

                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<bool>> DeleteAssignmentAsync(int id)
        {
            try
            {
                var delete = await _context.Assignments.Where(x => x.Id == id).ExecuteDeleteAsync();
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

        public async Task<PageResponse<List<GetAssignmentDto>>> GetAssignmentAsync(AssignmentFilter filter)
        {
            try
            {
                var assignments = _context.Assignments.AsQueryable();
                if (!string.IsNullOrEmpty(filter.Title))
                {
                    assignments = assignments.Where(x => x.Title!.ToLower().Contains(filter.Title.ToLower()));
                }
                if (!string.IsNullOrEmpty(filter.Description))
                {
                    assignments = assignments.Where(x => x.Description!.Contains(filter.Description));
                }

                var response = await assignments
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize).ToListAsync();
                var totalRecord = assignments.Count();

                var mapped = _mapper.Map<List<GetAssignmentDto>>(response);

                return new PageResponse<List<GetAssignmentDto>>(mapped, filter.PageNumber, filter.PageSize, totalRecord);
            }
            catch (Exception e)
            {

                return new PageResponse<List<GetAssignmentDto>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<GetAssignmentDto>> GetAssignmentByIdAsync(int id)
        {
            try
            {
                var exist = await _context.Assignments.FirstOrDefaultAsync(x => x.Id == id);
                if (exist == null)
                {
                    return new Response<GetAssignmentDto>(HttpStatusCode.BadRequest, "Not found");
                }
                var mapped = _mapper.Map<GetAssignmentDto>(exist);

                return new Response<GetAssignmentDto>(mapped);
            }
            catch (Exception e)
            {

                return new Response<GetAssignmentDto>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<string>> UpdateAssignmentAsync(UpdateAssignmentDto assignmentDto)
        {
            try
            {
                var mapped = _mapper.Map<Assignment>(assignmentDto);
                _context.Assignments.Update(mapped);

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
