using gs_csharp.src.Data;
using gs_csharp.src.Repositories;
using gs_csharp.src.Repositories.Interfaces;
using gs_csharp.src.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IFutureCareerRepository, FutureCareerRepository>();
builder.Services.AddScoped<IGapAnalysisRepository, GapAnalysisRepository>();
builder.Services.AddScoped<IUserSkillRepository, UserSkillRepository>();

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<UserSkillService>();
builder.Services.AddScoped<FutureCareerService>();
builder.Services.AddScoped<GapAnalysisService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => Results.Redirect("/swagger"))
   .ExcludeFromDescription();

app.UseAuthorization();
app.MapControllers();

app.Run();
