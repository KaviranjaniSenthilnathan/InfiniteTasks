using EmployeeManagement.API.DTOs.Department;
using EmployeeManagement.API.Model;
using EmployeeManagement.API.Repository.Interfaces;
using EmployeeManagement.API.Services.Interfaces;

namespace EmployeeManagement.API.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentService(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllAsync()
        {
            var departments = await _repository.GetAllAsync();

            return departments.Select(d => new DepartmentDto
            {
                DepartmentID = d.DepartmentID,
                DepartmentName = d.DepartmentName,
                CreatedDate = d.CreatedDate
            });
        }

        public async Task<DepartmentDto?> GetByIdAsync(int id)
        {
            var department = await _repository.GetByIdAsync(id);

            if (department == null)
                return null;
            return new DepartmentDto
            {
                DepartmentID = department.DepartmentID,
                DepartmentName = department.DepartmentName,
                CreatedDate = department.CreatedDate
            };
        }

        public async Task CreateAsync(CreateDepartmentDto dto)
        {
            var department = new Department
            {
                DepartmentName = dto.DepartmentName
            };
            await _repository.AddAsync(department);
            await _repository.SaveAsync();
        }

        public async Task UpdateAsync(int id, UpdateDepartmentDto dto)
        {
            var department = await _repository.GetByIdAsync(id);

            if (department == null)
                throw new Exception("Department not found!!!");

            department.DepartmentName = dto.DepartmentName;

            await _repository.UpdateAsync(department);
            await _repository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var department = await _repository.GetByIdAsync(id);

            if (department == null)
                throw new Exception("Department not found!!!");

            await _repository.DeleteAsync(department);
            await _repository.SaveAsync();
        }
    }
}