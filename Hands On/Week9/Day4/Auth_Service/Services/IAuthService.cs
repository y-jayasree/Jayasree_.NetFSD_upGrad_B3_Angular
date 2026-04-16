using AuthService.DTOs;
using AuthService.Models;
namespace AuthService.Services
{
    public interface IAuthService
    {
        Task<string> RegisterUser(RegisterDto dto);
        Task<string> RegisterAdmin(RegisterDto dto);
        Task<string> Login(LoginDto dto);
    }
}
