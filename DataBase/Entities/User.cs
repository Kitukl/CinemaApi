namespace WebApplication2.DataBase.Entities;

public class User
{
  public Guid Id { get; set; }
  public string UserName { get; set; } = string.Empty;
  public string Password { get; set; } = string.Empty;
  public List<FilmsList> FilmsLists { get; set; } = [];
}