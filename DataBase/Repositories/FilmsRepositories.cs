using Microsoft.EntityFrameworkCore;
using WebApplication2.DataBase.Entities;
using WebApplication2.IRepositories;

namespace WebApplication2.DataBase.Repositories;

public class FilmsRepositories : IFilmsRepository
{

  private readonly CinemaDbContext _dbContext;

  public FilmsRepositories(CinemaDbContext dbContext)
  {
    _dbContext = dbContext;
  }
  
  public async Task<List<Film>> Get()
  {
    return await _dbContext.Films.AsNoTracking().ToListAsync();
  }

  public async Task<Film?> GetByTitle(string title)
  {
    return await _dbContext.Films
      .AsNoTracking()
      .FirstOrDefaultAsync(f => f.Title.ToLower() == title.ToLower());
  }
}