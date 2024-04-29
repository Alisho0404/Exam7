using AutoMapper;
using Domain.DTO_s.SubmissionDTO;
using Domain.Enteties;
using Domain.Filters;
using Domain.Response;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Infrastructure.Services.SubmissionService
{
    public class SubmissionService : ISubmissionService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public SubmissionService(DataContext context,IMapper mapper)
        {
            _context=context;
            _mapper=mapper;
        }
        public async Task<Response<string>> AddSubmissionAsync(AddSubmissionDto submissionDto)
        {
            try
            {
               
                
                var mapped = _mapper.Map<Submission>(submissionDto);

                await _context.Submissions.AddAsync(mapped);
                await _context.SaveChangesAsync();
                return new Response<string>("Succesfully added");


            }
            catch (Exception e)
            {

                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<bool>> DeleteSubmissionAsync(int id)
        {
            try
            {
                var delete = await _context.Submissions.Where(x => x.Id == id).ExecuteDeleteAsync();
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

        public async Task<PageResponse<List<GetSubmissionDto>>> GetSubmissionAsync(SubmissionFilter filter)
        {
            try
            {
                var submissions = _context.Submissions.AsQueryable();
                if (!string.IsNullOrEmpty(filter.Content))
                {
                    submissions = submissions.Where(x => x.Content!.ToLower().Contains(filter.Content.ToLower()));
                }
                

                var response = await submissions
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize).ToListAsync();
                var totalRecord = submissions.Count();

                var mapped = _mapper.Map<List<GetSubmissionDto>>(response);

                return new PageResponse<List<GetSubmissionDto>>(mapped, filter.PageNumber, filter.PageSize, totalRecord);
            }
            catch (Exception e)
            {

                return new PageResponse<List<GetSubmissionDto>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<GetSubmissionDto>> GetSubmissionByIdAsync(int id)
        {
            try
            {
                var exist = await _context.Submissions.FirstOrDefaultAsync(x => x.Id == id);
                if (exist == null)
                {
                    return new Response<GetSubmissionDto>(HttpStatusCode.BadRequest, "Not found");
                }
                var mapped = _mapper.Map<GetSubmissionDto>(exist);

                return new Response<GetSubmissionDto>(mapped);
            }
            catch (Exception e)
            {

                return new Response<GetSubmissionDto>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<string>> UpdateSubmissionAsync(UpdateSubmissionDto submissionDto)
        {
            try
            {
                var mapped = _mapper.Map<Submission>(submissionDto);
                _context.Submissions.Update(mapped);

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
