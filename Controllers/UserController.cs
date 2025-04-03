using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
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

  [HttpPost("add/user")]
  public async Task<IActionResult> Add(UserModel addFilmsListRequest)
  {
    if (!string.IsNullOrWhiteSpace(addFilmsListRequest.Username) &&
        !string.IsNullOrWhiteSpace(addFilmsListRequest.Password))
    {
      var username = addFilmsListRequest.Username;
      var password = addFilmsListRequest.Password;
      if (password.Length >= 8)
      {
        await _userService.Add(username, password);
        return Ok();
      }
      else
      {
        return BadRequest("Password must be >= 8");
      }
    }
    else
    {
      return BadRequest();
    }
  }

  [HttpDelete("delete/user/{id}")]
  public async Task<IActionResult> Delete(Guid id)
  {
    await _userService.Delete(id);
    return Ok($"User with {id} was removed");
  }
}
