using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Modules.AuthModule.DTOs;
using WebApplication1.Modules.AuthModule.Interfaces;

namespace WebApplication1.Modules.AuthModule.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        await _authService.RegisterAsync(dto);
        return Ok(new { Message = "User registered successfully." });
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        await _authService.LoginAsync(dto, Response);
        return Ok(new { Message = "Logged in successfully." });
    }

    [HttpPost("refresh")]
    [AllowAnonymous]
    public async Task<IActionResult> Refresh([FromBody] RefreshDto dto)
    {
        await _authService.RefreshTokenAsync(dto, Response);
        return Ok(new { Message = "Token refreshed successfully." });
    }

    [HttpPost("logout")]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        var userId = User.FindFirst(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
            return Unauthorized();

        await _authService.LogoutAsync(Guid.Parse(userId));

        Response.Cookies.Delete("jwt");
        Response.Cookies.Delete("refresh_token");

        return Ok(new { Message = "Logged out successfully." });
    }

}