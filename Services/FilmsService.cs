using WebApplication2.DataBase.Entities;
using WebApplication2.IServices;
using WebApplication2.IRepositories;

public class FilmsService : IFilmsService
{

  private readonly IFilmsRepository _films;

  public FilmsService(IFilmsRepository films)
  {
    _films = films;
  }
  public async Task<List<Film>> Get()
  {
    return await _films.Get();
  }

  public async Task<Film> GetByTitle(string title)
  {
    return await _films.GetByTitle(title);
  }
}