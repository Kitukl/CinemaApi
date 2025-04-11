using WebApplication2.DataBase.Entities;
using WebApplication2.IRepositories;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.DataBase.Repositories;

public class UserRepository : IUserRepository
{

  private readonly CinemaDbContext _cinema;

  public UserRepository(CinemaDbContext cinema)
  {
    _cinema = cinema;
  }
  
  public async Task Add(string username, string password)
  {
    var user = new User() {Id = Guid.NewGuid(), UserName = username, Password = BCrypt.Net.BCrypt.HashPassword(password)};
    await _cinema.Users.AddAsync(user);
    await _cinema.SaveChangesAsync();
  }

  public async Task<User?> GetById(Guid id)
  {
    return await _cinema.Users
      .FirstOrDefaultAsync(u => u.Id == id);
  }

  public async Task<User?> Get(string username)
  {
    return await _cinema.Users
      .FirstOrDefaultAsync(u => u.UserName == username);
  }
  
  public Task ChangeUsername(string username, string password)
  {
    throw new NotImplementedException();
  }

  public async Task Delete(Guid id)
  {
    await _cinema.Users
      .Where(u => u.Id == id)
      .ExecuteDeleteAsync();
    await _cinema.SaveChangesAsync();
  }
}