using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication2.DataBase.Entities;

public class FilmsListConfigurations : IEntityTypeConfiguration<FilmsList>
{
  public void Configure(EntityTypeBuilder<FilmsList> builder)
  {
    builder.HasKey(fl => fl.Id);

    builder.HasMany<Film>(fl => fl.Films).WithMany();
    builder.HasOne<User>(fl => fl.User).WithMany(u => u.FilmsLists).OnDelete(DeleteBehavior.Restrict);
  }
}