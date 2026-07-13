using Microsoft.EntityFrameworkCore;
using EmployeeManagement.API.Data;
using EmployeeManagement.API.Model;
using EmployeeManagement.API.Repository.Interfaces;

namespace EmployeeManagement.API.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByUserNameAsync(string userName)
        {
            return await _context.ApplicationUsers.FirstOrDefaultAsync(u => u.UserName == userName);
        }

        public async Task AddAsync(User user)
        {
            await _context.ApplicationUsers.AddAsync(user);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}