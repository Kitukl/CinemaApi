namespace WebApplication2.IServices;

public interface IAuth
{
  public Task Register(string username, string password);
  public Task<string> Login(string username, string password);
}