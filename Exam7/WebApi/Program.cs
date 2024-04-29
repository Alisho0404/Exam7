using Infrastructure.AutoMapper;
using Infrastructure.Data;
using Infrastructure.Services.AssignmentService;
using Infrastructure.Services.CourseService;
using Infrastructure.Services.FeedBackService;
using Infrastructure.Services.MaterialService;
using Infrastructure.Services.QueryService;
using Infrastructure.Services.StudentService;
using Infrastructure.Services.SubmissionService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Connection"));
});

builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IAssignmnetService, AssignmnetService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IFeedBackService, FeedBackService>();
builder.Services.AddScoped<IMaterialService, MaterialService>();
builder.Services.AddScoped<ISubmissionService, SubmissionService>();
builder.Services.AddScoped<IQueryService, QueryService>();


builder.Services.AddAutoMapper(typeof(MapperProfile));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();


