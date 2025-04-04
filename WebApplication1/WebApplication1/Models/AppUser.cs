using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class AppUser : IdentityUser
{
    public int Coins { get; set; }
    public int Experience { get; set; }
    public int AmountSolved { get; set; }
    public string? ProfilePicture { get; set; }

    public Guid? CohortId { get; set; }
    [ForeignKey("CohortId")]
    public Cohort? Cohort { get; set; }

    public Guid? UserRoleId { get; set; }
}
