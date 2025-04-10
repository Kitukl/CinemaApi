using WebApplication2.DataBase;
using WebApplication2.DataBase.Repositories;
using WebApplication2.IRepositories;
using WebApplication2.IServices;
using WebApplication2.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<IFilmsService, FilmsService>();
builder.Services.AddScoped<IFilmsRepository, FilmsRepositories>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IFilmsListRepository, FilmsListRepository>();
builder.Services.AddScoped<IFilmsListService, FilmsListService>();
builder.Services.AddDbContext<CinemaDbContext>();
builder.Services.AddCors(options =>
{
  options.AddDefaultPolicy(policy =>
  {
    policy.AllowAnyOrigin();
    policy.AllowAnyHeader();
    policy.AllowAnyMethod();
  });
});
var app = builder.Build();

app.UseCors();
app.UseRouting();
app.MapControllers();

app.Run();