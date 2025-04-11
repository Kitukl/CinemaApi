using WebApplication2.DataBase.Entities;
using WebApplication2.DTOs;
using WebApplication2.IRepositories;
using WebApplication2.IServices;

namespace WebApplication2.Services;

public class FilmsListService : IFilmsListService
{

  private readonly IFilmsListRepository _listRepository;

  public FilmsListService(IFilmsListRepository listRepository)
  {
    _listRepository = listRepository;
  }
  
  public async Task Add(string title, Guid userID, List<Guid> Films)
  {
    await _listRepository.Add(title, userID, Films);
  }

  public async Task<List<FilmsListDTO>> GetForUser(Guid id)
  {
    return await _listRepository.GetForUser(id);
  }

  public async Task<FilmsListDTO> GetById(Guid id)
  {
    return await _listRepository.GetById(id);
  }

  public async Task Change(Guid id, string title)
  {
    await _listRepository.Change(id, title);
  }

  public async Task Delete(Guid id)
  {
    await _listRepository.Delete(id);
  }
}