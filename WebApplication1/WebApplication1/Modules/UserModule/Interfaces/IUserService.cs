using WebApplication1.Modules.UserModule.DTOs;

namespace WebApplication1.Modules.UserModule.Interfaces
{
    public interface IUserService
    {
        Task<UserProfileDto> GetProfileAsync(Guid userId);
        Task UpdateProfileAsync(Guid userId, UpdateUserDto dto);
    }
}