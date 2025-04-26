namespace WebApplication1.Modules.UserModule.DTOs;

public class UpdateUserDto
{
    public required string Username { get; set; }
    public required string Email { get; set; }
    public string? ProfilePicture { get; set; }
}