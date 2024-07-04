using Microsoft.AspNetCore.Mvc;

namespace InvenEase.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    [HttpPost("register")]
    public IActionResult Register()
    {
        return Ok();
    }

    [HttpPost("login")]
    public IActionResult Login()
    {
        return Ok();
    }
}