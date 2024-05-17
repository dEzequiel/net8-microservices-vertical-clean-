using Auth.Service.DTOs;

namespace Auth.Service.Data
{
    public interface IApplicationUserRepository
    {
        Task<RegisterApplicationUserResponse> RegisterApplicationUserAsync(RegisterApplicationUserDTO registerUser);
        Task<LoginApplicationUserResponse> LoginApplicationUserAsync(LoginApplicationUserDTO loginUser);
    }
}
