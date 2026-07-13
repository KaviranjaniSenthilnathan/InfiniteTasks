using Microsoft.EntityFrameworkCore;
using EmployeeManagement.API.Data;
using EmployeeManagement.API.Model;
using EmployeeManagement.API.Repository.Interfaces;

namespace EmployeeManagement.API.Repository.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.Include(e => e.Department).ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees.Include(e => e.Department)
                                 .FirstOrDefaultAsync(e => e.EmployeeID == id);
        }

        public async Task<IEnumerable<Employee>> SearchByNameAsync(string name)
        {
            return await _context.Employees.Where(e => e.EmployeeName.Contains(name))
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetByDepartmentAsync(int departmentId)
        {
            return await _context.Employees.Where(e => e.DepartmentID == departmentId)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetBySalaryRangeAsync(decimal min, decimal max)
        {
            return await _context.Employees.Where(e => e.Salary >= min && e.Salary <= max)
                                 .ToListAsync();
        }

        public async Task AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
        }

        public Task UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Employee employee)
        {
            _context.Employees.Remove(employee);
            return Task.CompletedTask;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}