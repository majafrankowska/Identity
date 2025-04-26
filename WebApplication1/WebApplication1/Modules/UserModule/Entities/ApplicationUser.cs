using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Modules.UserModule.Entities;

public class ApplicationUser : IdentityUser<Guid>
{
    public int Coins { get; set; } = 0;
    public int Experience { get; set; } = 0;
    public int AmountSolved { get; set; } = 0;
    public string? ProfilePicture { get; set; }
    public Guid? CohortId { get; set; }

    public Guid? UserRoleId { get; set; }
    public UserRole? UserRole { get; set; }

    public ICollection<WebApplication1.Modules.AuthModule.Entities.Session>? Sessions { get; set; }
}