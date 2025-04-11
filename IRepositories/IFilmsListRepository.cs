using WebApplication2.DataBase.Entities;
using WebApplication2.DTOs;

namespace WebApplication2.IRepositories;

public interface IFilmsListRepository
{
  public Task Add(string title, Guid userID, List<Guid> Films);
  public Task<List<FilmsListDTO>> GetForUser(Guid id);
  public Task<FilmsListDTO> GetById(Guid id);
  public Task Change(Guid id, string title);
  public Task Delete(Guid id);
}