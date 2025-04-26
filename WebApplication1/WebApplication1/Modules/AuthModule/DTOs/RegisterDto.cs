namespace WebApplication1.Modules.AuthModule.DTOs;

public class RegisterDto
{
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public Guid? CohortId { get; set; } 
}
