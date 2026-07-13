using EmployeeManagement.API.DTOs.Auth;

namespace EmployeeManagement.API.Services.Interfaces
{
    public interface IUserService
    {
        Task RegisterAsync(RegisterDto dto);

        Task<string?> LoginAsync(LoginDto dto);
    }
}