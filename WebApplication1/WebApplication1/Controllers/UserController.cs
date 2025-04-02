using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApplication1.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    [HttpGet("profile")]
    public IActionResult Profile()
    {
        var email = User.FindFirstValue(ClaimTypes.NameIdentifier); // albo JwtRegisteredClaimNames.Sub
        return Ok(new { email });
    }
}