namespace WebApplication2.DataBase.Entities;

public class FilmsList
{
  public Guid Id { get; set; }
  public string Title { get; set; } = string.Empty;
  public List<Film> Films { get; set; }
  public User User { get; set; }
}