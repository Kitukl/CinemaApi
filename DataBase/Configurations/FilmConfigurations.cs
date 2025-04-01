using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication2.DataBase.Entities;

public class FilmConfigurations : IEntityTypeConfiguration<Film>
{
  public void Configure(EntityTypeBuilder<Film> builder)
  {
    builder.HasKey(f => f.Id);

    builder.HasMany<FilmsList>().WithMany();
  }
}