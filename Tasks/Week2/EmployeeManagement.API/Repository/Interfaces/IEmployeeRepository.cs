using EmployeeManagement.API.Model;

namespace EmployeeManagement.API.Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();

        Task<Employee?> GetByIdAsync(int id);

        Task<IEnumerable<Employee>> SearchByNameAsync(string name);

        Task<IEnumerable<Employee>> GetByDepartmentAsync(int departmentId);

        Task<IEnumerable<Employee>> GetBySalaryRangeAsync(decimal min, decimal max);

        Task AddAsync(Employee employee);

        Task UpdateAsync(Employee employee);

        Task DeleteAsync(Employee employee);

        Task SaveAsync();
    }
}