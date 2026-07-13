using EmployeeManagement.API.Model;

namespace EmployeeManagement.API.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByUserNameAsync(string userName);

        Task AddAsync(User user);

        Task SaveAsync();
    }
}