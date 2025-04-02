namespace WebApplication1.Models;

public class PromoteUserDto
{
    public required string Email { get; set; }
    public required string Role { get; set; } = "admin";
}