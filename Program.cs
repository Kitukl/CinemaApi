using System.Text;
using Microsoft.IdentityModel.Tokens;
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
builder.Services.AddScoped<Auth>();
builder.Services.AddScoped<JWTProvider>();
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));
builder.Services.AddDbContext<CinemaDbContext>();
builder.Services.AddAuthentication(options =>
  {
    options.DefaultAuthenticateScheme = "Bearer";
    options.DefaultChallengeScheme = "Bearer";
  })
  .AddJwtBearer("Bearer", options =>
  {
    options.TokenValidationParameters = new TokenValidationParameters()
    {
      ValidateIssuer = false,
      ValidateAudience = false,
      ValidateLifetime = true,
      ValidateIssuerSigningKey = true,
      IssuerSigningKey = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(builder.Configuration["JwtOptions:SecretKey"]!))
    };
  });
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

app.UseRouting();
app.UseCors();
app.UseAuthentication();     
app.UseAuthorization();      
app.MapControllers();       

app.Run();