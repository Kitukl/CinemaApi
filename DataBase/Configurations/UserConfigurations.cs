using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication2.DataBase.Entities;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {
    builder.HasKey(u => u.Id);

    builder.HasMany<FilmsList>(u => u.FilmsLists).WithOne(fl => fl.User).OnDelete(DeleteBehavior.Cascade);
  }
}