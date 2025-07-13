using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyPrj.Application.Auth.Command;
using MyPrj.Application.Services;
using MyPrj.Domain.Interface;

namespace Sample_prj_DDDauth.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
  private readonly IMediator _mediator;

  public AuthController( IMediator mediator)
  {
    _mediator = mediator;
  
  }

  [HttpPost("login")]
  public async Task<IActionResult> Login([FromBody] LogUserCommand input)
  {
    var token = await _mediator.Send(input);
    return Ok(token);
  }

  [HttpPost("register")]
  public async Task<IActionResult> Register([FromBody] AddUserCommand input)
  {
    await _mediator.Send(input);
    return Ok();
  }
  [HttpGet("me")]
  public IActionResult WhoAmI([FromServices] ICurrentUserService user)
  {
    return Ok(user.UserId);
  }
  
  public record LoginDto(string Email, string Password);
  public record RegisterDto(string Email, string Password);
}
