using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.IServices;
using WebApplication2.Models;

namespace WebApplication2.Controllers;

[ApiController]
public class FilmsListController : ControllerBase
{

  private readonly IFilmsListService _films;

  public FilmsListController(IFilmsListService films)
  {
    _films = films;
  }
  [Authorize]
  [HttpPost("add/list")]
  public async Task<ActionResult> Add([FromBody] FilmsListModel filmsListModel)
  {
    await _films.Add(filmsListModel.Title, filmsListModel.UserId, filmsListModel.FilmsId);
    return Ok("Дані пішли в БД");
  }
  [Authorize]
  [HttpGet("list/{id}")]
  public async Task<ActionResult> Get(Guid id)
  {
    var filmsLists = await _films.GetForUser(id);
    return new JsonResult(filmsLists);
  }
  
  [Authorize]
  [HttpGet("lists/{id}")]
  public async Task<ActionResult> GetById(Guid id)
  {
    var filmsList = await _films.GetById(id);
    return new JsonResult(filmsList);
  }

  [Authorize]
  [HttpPut("/lists/{id}")]
  public async Task<ActionResult> Change(Guid id, UpdateListModel dto)
  {
    await _films.Change(id, dto.Title);
    return Ok($"Cписок з айді {id}, змінено назву на {dto.Title}");
  }
  
  [Authorize]
  [HttpDelete("lists/{id}")]
  public async Task<ActionResult> Delete(Guid id)
  {
    await _films.Delete(id);
    return Ok($"Список {id}Б видалено успішно");
  }
}