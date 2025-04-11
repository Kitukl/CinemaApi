using Microsoft.AspNetCore.Mvc;
using WebApplication2.DTOs;
using WebApplication2.IServices;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{

  private readonly Auth _auth;

  public AuthController(Auth auth)
  {
    _auth = auth;
  }
  
  [HttpPost("register")]
  public async Task<ActionResult> Register([FromBody] RegisterDTO registerDto)
  {
    await _auth.Register(registerDto.Username, registerDto.Password);
    return Ok("Користувача зареєстровано");
  }
  
  [HttpPost("login")]
  public async Task<ActionResult> Login([FromBody] LoginDTO loginDto)
  {
    var token = await _auth.Login(loginDto.Username, loginDto.Password);
    return Ok(token);
  }
}