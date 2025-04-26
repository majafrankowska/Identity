namespace WebApplication1.Modules.AuthModule.Jwt;

public class JwtSettings
{
    public required string Key { get; set; }
    public required string Issuer { get; set; }
    public required string Audience { get; set; }
    public double DurationInMinutes { get; set; }
}
