using Microsoft.AspNetCore.Mvc;
using WebApplication2.IServices;

namespace WebApplication2.Controllers;
[ApiController]
public class FilmController : ControllerBase
{

  private readonly IFilmsService _filmsService;

  public FilmController(IFilmsService filmsService)
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
    if (string.IsNullOrWhiteSpace(title))
    {
      return BadRequest();
    }
    var film = await _filmsService.GetByTitle(title);
    if (film == null)
    {
      return NotFound();
    }

    return new JsonResult(film);
  }
}