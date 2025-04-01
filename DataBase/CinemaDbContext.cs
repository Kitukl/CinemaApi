using Microsoft.EntityFrameworkCore;
using WebApplication2.DataBase.Entities;

namespace WebApplication2.DataBase;

public class CinemaDbContext : DbContext
{
  private IConfiguration _configuration;
  public CinemaDbContext(IConfiguration configuration)
  {
    _configuration = configuration;
  }

  public DbSet<Film> Films { get; set; }
  public DbSet<User> Users { get; set; }
  public DbSet<FilmsList> FilmsLists { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(CinemaDbContext).Assembly);
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Cinema"));
  }
}