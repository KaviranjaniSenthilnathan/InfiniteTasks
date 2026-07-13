using EmployeeManagement.API.DTOs.Employee;

namespace EmployeeManagement.API.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllAsync();

        Task<EmployeeDto?> GetByIdAsync(int id);

        Task<IEnumerable<EmployeeDto>> SearchByNameAsync(string name);

        Task<IEnumerable<EmployeeDto>> GetByDepartmentAsync(int departmentId);

        Task<IEnumerable<EmployeeDto>> GetBySalaryRangeAsync(decimal min, decimal max);

        Task CreateAsync(CreateEmployeeDto dto);

        Task UpdateAsync(int id, UpdateEmployeeDto dto);

        Task DeleteAsync(int id);
    }
}