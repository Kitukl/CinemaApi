using WebApplication2.DataBase.Entities;
using WebApplication2.IRepositories;
using WebApplication2.IServices;

namespace WebApplication2.Services;

public class UserService : IUserService
{

  private readonly IUserRepository _repository;

  public UserService(IUserRepository repository)
  {
    _repository = repository;
  }
  
  public async Task Add(string username, string password)
  {
    await _repository.Add(username, password);
  }

  public async Task<User> Get(string username)
  {
    return await _repository.Get(username);
  }

  public Task ChangeUsername(string username, string password)
  {
    throw new NotImplementedException();
  }

  public async Task Delete(Guid id)
  {
    await _repository.Delete(id);
  }
}