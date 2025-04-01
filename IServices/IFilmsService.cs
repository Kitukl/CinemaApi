using WebApplication2.DataBase.Entities;

namespace WebApplication2.IServices;

public interface IFilmsService
{
  public Task<List<Film>> Get();
  public Task<Film> GetByTitle(string title);
}