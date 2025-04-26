namespace WebApplication1.Modules.UserModule.DTOs;

public class UserProfileDto
{
    public required string Username { get; set; }
    public required string Email { get; set; }
    public int Coins { get; set; }
    public int Experience { get; set; }
    public int AmountSolved { get; set; }
    public string? ProfilePicture { get; set; }
    public required string Role { get; set; }
}