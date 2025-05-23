using WebApplication1.Modules.UserModule.Models;
using System.Security.Claims;


namespace WebApplication1.Modules.AuthModule.Interfaces;

public interface ITokenService
{
    string CreateAccessToken(ApplicationUser user);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}
