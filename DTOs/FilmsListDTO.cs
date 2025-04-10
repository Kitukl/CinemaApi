using WebApplication2.DataBase.Entities;

namespace WebApplication2.DTOs;

public class FilmsListDTO
{
  public Guid Id { get; set; }
  public string Title { get; set; }
  public List<Film> Films { get; set; }
  public string Username { get; set; }
}