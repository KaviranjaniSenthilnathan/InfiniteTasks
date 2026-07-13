using EmployeeManagement.API.DTOs.Department;

namespace EmployeeManagement.API.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDto>> GetAllAsync();

        Task<DepartmentDto?> GetByIdAsync(int id);

        Task CreateAsync(CreateDepartmentDto dto);

        Task UpdateAsync(int id, UpdateDepartmentDto dto);

        Task DeleteAsync(int id);
    }
}