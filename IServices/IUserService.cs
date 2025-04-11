namespace WebApplication2.IServices;
using WebApplication2.DataBase.Entities;

public interface IUserService
{
  public Task Add(string username, string password);
  public Task<User> Get(string username);
  public Task<User> GetById(Guid id);
  public Task ChangeUsername(string username, string password);
  public Task Delete(Guid id);
}