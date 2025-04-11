using WebApplication2.DataBase.Entities;

namespace WebApplication2.IRepositories;

public interface IUserRepository
{
  public Task Add(string username, string password);
  public Task<User> GetById(Guid id);
  public Task<User> Get(string username);
  public Task ChangeUsername(string username, string password);
  public Task Delete(Guid id);
}