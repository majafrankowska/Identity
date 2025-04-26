using WebApplication1.Modules.UserModule.Entities;

namespace WebApplication1.Modules.AuthModule.Entities;

public class Session
{
    public Guid SessionId { get; set; } = Guid.NewGuid();
    public required string RefreshToken { get; set; }
    public DateTime RefreshTokenExpiresAt { get; set; }
    public bool Revoked { get; set; } = false;

    public Guid UserId { get; set; }
    public required ApplicationUser User { get; set; }
}

