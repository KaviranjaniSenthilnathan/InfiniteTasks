using EmployeeManagement.API.Model;

namespace EmployeeManagement.API.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}