using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.DataBase.Entities;
using WebApplication2.IServices;
using WebApplication2.Models;

namespace WebApplication2.Controllers;

[ApiController]
public class UserController : ControllerBase
{
  private readonly IUserService _userService;

  public UserController(IUserService userService)
  {
    _userService = userService;
  }

  [HttpGet("users/{id}")]
  public async Task<ActionResult> GetById(Guid id)
  {
    var user = await _userService.GetById(id);
    return Ok(user);
  } 

  [HttpDelete("delete/user/{id}")]
  public async Task<IActionResult> Delete(Guid id)
  {
    await _userService.Delete(id);
    return Ok($"User with {id} was removed");
  }
}
