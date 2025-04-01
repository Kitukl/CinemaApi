using WebApplication2.DataBase;
using WebApplication2.DataBase.Repositories;
using WebApplication2.IRepositories;
using WebApplication2.IServices;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<IFilmsService, FilmsService>();
builder.Services.AddScoped<IFilmsRepository, FilmsRepositories>();
builder.Services.AddDbContext<CinemaDbContext>();
var app = builder.Build();

app.UseRouting();
app.MapControllers();

app.Run();