using AutoMapper;
using Domain.DTO_s.FeedBackDTO;
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

namespace Infrastructure.Services.FeedBackService
{
    public class FeedBackService : IFeedBackService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public FeedBackService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Response<string>> AddFeedbackAsync(AddFeedbackDto feedbackDto)
        {
            try
            {

                var mapped = _mapper.Map<Feedback>(feedbackDto);

                await _context.Feedbacks.AddAsync(mapped);
                await _context.SaveChangesAsync();
                return new Response<string>("Succesfully added");


            }
            catch (Exception e)
            {

                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<bool>> DeleteFeedbackAsync(int id)
        {
            try
            {
                var delete = await _context.Feedbacks.Where(x => x.Id == id).ExecuteDeleteAsync();
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

        public async Task<PageResponse<List<GetFeedbackDto>>> GetFeedbacksAsync(FeedbackFilter filter)
        {
            try
            {
                var feedbacks = _context.Feedbacks.AsQueryable();
                if (!string.IsNullOrEmpty(filter.Text))
                {
                    feedbacks = feedbacks.Where(x => x.Text!.ToLower().Contains(filter.Text.ToLower()));
                }


                var response = await feedbacks
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize).ToListAsync();
                var totalRecord = feedbacks.Count();

                var mapped = _mapper.Map<List<GetFeedbackDto>>(response);

                return new PageResponse<List<GetFeedbackDto>>(mapped, filter.PageNumber, filter.PageSize, totalRecord);
            }
            catch (Exception e)
            {

                return new PageResponse<List<GetFeedbackDto>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<GetFeedbackDto>> GetFeedbackByIdAsync(int id)
        {
            try
            {
                var exist = await _context.Feedbacks.FirstOrDefaultAsync(x => x.Id == id);
                if (exist == null)
                {
                    return new Response<GetFeedbackDto>(HttpStatusCode.BadRequest, "Not found");
                }
                var mapped = _mapper.Map<GetFeedbackDto>(exist);

                return new Response<GetFeedbackDto>(mapped);
            }
            catch (Exception e)
            {

                return new Response<GetFeedbackDto>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<Response<string>> UpdateFeedbackAsync(UpdateFeedbackDto feedbackDto)
        {
            try
            {
                var mapped = _mapper.Map<Feedback>(feedbackDto);
                _context.Feedbacks.Update(mapped);

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

        public async Task<PageResponse<List<GetProvideFeedbackDto>>> GetProvideFeedbacksAsync(FeedbackFilter filter)
        {
            try
            {
                var feedbacks = await (from f in _context.Feedbacks
                                       join s in _context.Students on f.StudentId equals s.Id
                                       join a in _context.Assignments on f.AssignmentId equals a.Id
                                       select new GetProvideFeedbackDto
                                       {
                                           StudentName = s.Name,
                                           AdmissionTitle = a.Title!,
                                           AdmisiionDescription = a.Description,
                                           FeedbackText = f.Text!,
                                           FeedbackDate = f.FeedBackDate
                                       }).ToListAsync();
                var response = feedbacks
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize).ToList();
                var totalRecore = feedbacks.Count(); 
                return new PageResponse<List<GetProvideFeedbackDto>>(response,filter.PageNumber,filter.PageSize,totalRecore);
            }
            catch (Exception e)
            {

                return new PageResponse<List<GetProvideFeedbackDto>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<PageResponse<List<GetFeedbackForAssignmentDto>>> GetFeedBacksForAssignment(FeedbackFilter filter)
        {
            try
            {
                string zadanie = "AssignmentName";
                var feedbacks = await (from f in _context.Feedbacks
                                       join a in _context.Assignments on f.AssignmentId equals a.Id
                                       where a.Title == zadanie
                                       select new GetFeedbackForAssignmentDto {
                                           AssignmentTitle = a.Title!,
                                           AssignmentDescription = a.Description,
                                           AssignmentDueDate = a.DueDate,
                                           Feedback = f.Text!
                                       }).ToListAsync(); 
                var response=feedbacks
                    .Skip((filter.PageNumber-1)*filter.PageSize)
                    .Take(filter.PageSize).ToList();
                var totalRecord= feedbacks.Count();
                return new PageResponse<List<GetFeedbackForAssignmentDto>>(response, filter.PageNumber, filter.PageSize, totalRecord);

                    
            }
            catch (Exception e)
            {
                return new PageResponse<List<GetFeedbackForAssignmentDto>>(HttpStatusCode.InternalServerError, e.Message);
                
            }
        }
    }
}
