using WebApplication2.IRepositories;
using WebApplication2.IServices;

namespace WebApplication2.Services;

public class Auth : IAuth
{
  private readonly IUserRepository _user;
  private readonly JWTProvider _jwtProvider;

  public Auth(IUserRepository user, JWTProvider jwtProvider)
  {
    _user = user;
    _jwtProvider = jwtProvider;
  }
  
  public async Task Register(string username, string password)
  {
    await _user.Add(username, password);
  }

  public async Task<string> Login(string username, string password)
  {
    var user = await _user.Get(username);

    var result = BCrypt.Net.BCrypt.Verify(password, user.Password);

    if (!result) throw new Exception("Failed login");

    var token = _jwtProvider.GenerateToken(user);
    
    return token;
  }
}