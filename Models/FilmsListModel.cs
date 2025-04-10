namespace WebApplication2.Models;

public class FilmsListModel
{
  public string Title { get; set; } = string.Empty;
  public Guid UserId { get; set; }
  public List<Guid> FilmsId { get; set; }
}