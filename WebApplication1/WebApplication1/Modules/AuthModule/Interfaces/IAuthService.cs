using WebApplication1.Modules.AuthModule.DTOs;

namespace WebApplication1.Modules.AuthModule.Interfaces;

public interface IAuthService
{
    Task RegisterAsync(RegisterDto dto);
    Task LoginAsync(LoginDto dto, HttpResponse response);
    Task RefreshTokenAsync(RefreshDto dto, HttpResponse response);
    Task LogoutAsync(Guid userId);
}
