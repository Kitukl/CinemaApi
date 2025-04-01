using Microsoft.AspNetCore.Mvc;
using WebApplication2.IServices;

namespace WebApplication2.Controllers;
[ApiController]
public class FilmControllers : ControllerBase
{

  private readonly IFilmsService _filmsService;

  public FilmControllers(IFilmsService filmsService)
  {
    _filmsService = filmsService;
  }

  [HttpGet("films")]
  public async Task<ActionResult> GetFilms()
  {
    var films = await _filmsService.Get();
    return new JsonResult(films);
  }

  [HttpGet("films/{title}")]
  public async Task<ActionResult> GetFilmByTitle(string title)
  {
    var film = await _filmsService.GetByTitle(title);
    return new JsonResult(film);
  }
}