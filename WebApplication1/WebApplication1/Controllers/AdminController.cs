using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "admin")]
public class AdminController : ControllerBase
{
    [HttpGet("admin-only")]
    public IActionResult AdminStuff()
    {
        return Ok("Only for admin access");
    }

    [HttpPost("promote")]
    public async Task<IActionResult> PromoteUser(
        [FromBody] PromoteUserDto dto,
        [FromServices] UserManager<IdentityUser> userManager)
    {
        var user = await userManager.FindByEmailAsync(dto.Email);
        if (user == null)
            return NotFound(new { message = "User not found" });

        var result = await userManager.AddToRoleAsync(user, dto.Role);
        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return Ok(new { message = $"User {dto.Email} promoted to role '{dto.Role}'" });
    }
}