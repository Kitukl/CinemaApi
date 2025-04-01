using WebApplication2.DataBase.Entities;

namespace WebApplication2.IRepositories;

public interface IFilmsRepository
{
  public Task<List<Film>> Get();
  public Task<Film> GetByTitle(string title);
}