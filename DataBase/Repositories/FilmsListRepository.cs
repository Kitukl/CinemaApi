using Microsoft.EntityFrameworkCore;
using WebApplication2.DataBase.Entities;
using WebApplication2.DTOs;
using WebApplication2.IRepositories;

namespace WebApplication2.DataBase.Repositories;

public class FilmsListRepository : IFilmsListRepository
{

  private readonly CinemaDbContext _db;

  public FilmsListRepository(CinemaDbContext db)
  {
    _db = db;
  }
  
  public async Task Add(string title, Guid userID, List<Guid> Films)
  {
    var user = await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(_db.Users, u => u.Id == userID) ?? throw new Exception("No User - no funny");
    var films = new List<Film>();
    foreach (var filmId in Films)
    {
      var film = await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(_db.Films, f => f.Id == filmId) ?? throw new Exception("No film - no funny");
      films.Add(film);
    }

    var list = new FilmsList() { Id = Guid.NewGuid(), Title = title, Films = films, User = user};
    await _db.FilmsLists.AddAsync(list);
    await _db.SaveChangesAsync();
  }

  public async Task<List<FilmsListDTO>> Get()
  {
    return await _db.FilmsLists
      .Include(fl => fl.Films)
      .Include(fl => fl.User)
      .Select(fl => new FilmsListDTO()
      {
        Id = fl.Id,
        Title = fl.Title,
        Films = fl.Films,
        Username = fl.User.UserName
      })
      .ToListAsync();
  }

  public async Task<FilmsListDTO?> GetById(Guid id)
  {
    return await _db.FilmsLists
      .Where(c => c.Id == id)
      .Include(fl => fl.Films)
      .Include(fl => fl.User)
      .Select(fl => new FilmsListDTO()
      {
        Id = fl.Id,
        Title = fl.Title,
        Films = fl.Films,
        Username = fl.User.UserName
      }).FirstOrDefaultAsync();
  }

  public async Task Change(Guid id, string title)
  {
    await _db.FilmsLists
      .Where(fl => fl.Id == id)
      .ExecuteUpdateAsync(p => p.SetProperty(fl => fl.Title, title));
    await _db.SaveChangesAsync();
  }

  public async Task Delete(Guid id)
  {
    await _db.FilmsLists
      .Where(fl => fl.Id == id)
      .ExecuteDeleteAsync();
    await _db.SaveChangesAsync();
  }
}