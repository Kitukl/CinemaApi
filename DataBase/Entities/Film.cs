using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication2.DataBase.Entities;

public class Film
{
  public Guid Id { get; set; }
  public string Title { get; set; } = string.Empty;
  public string Poster { get; set; } = string.Empty;
  public double Rating { get; set; }
  public int Year { get; set; }
  
}