using EmployeeManagement.API.DTOs.Employee;
using EmployeeManagement.API.Model;
using EmployeeManagement.API.Repository.Interfaces;
using EmployeeManagement.API.Services.Interfaces;

namespace EmployeeManagement.API.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public EmployeeService(IEmployeeRepository employeeRepository,
                               IDepartmentRepository departmentRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();

            return employees.Select(e => new EmployeeDto
            {
                EmployeeID = e.EmployeeID,
                EmployeeName = e.EmployeeName,
                Email = e.Email,
                Salary = (decimal)e.Salary,
                JoinDate = e.JoiningDate,
                DepartmentID = e.DepartmentID,
                DepartmentName = e.Department?.DepartmentName ?? ""
            });
        }

        public async Task<EmployeeDto?> GetByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
                return null;

            return new EmployeeDto
            {
                EmployeeID = employee.EmployeeID,
                EmployeeName = employee.EmployeeName,
                Email = employee.Email,
                Salary = (decimal)employee.Salary,
                JoinDate = employee.JoiningDate,
                DepartmentID = employee.DepartmentID,
                DepartmentName = employee.Department?.DepartmentName ?? ""
            };
        }

        public async Task<IEnumerable<EmployeeDto>> SearchByNameAsync(string name)
        {
            var employees = await _employeeRepository.SearchByNameAsync(name);

            return employees.Select(e => new EmployeeDto
            {
                EmployeeID = e.EmployeeID,
                EmployeeName = e.EmployeeName,
                Email = e.Email,
                Salary = (decimal)e.Salary,
                JoinDate = e.JoiningDate,
                DepartmentID = e.DepartmentID
            });
        }

        public async Task<IEnumerable<EmployeeDto>> GetByDepartmentAsync(int departmentId)
        {
            var employees = await _employeeRepository.GetByDepartmentAsync(departmentId);

            return employees.Select(e => new EmployeeDto
            {
                EmployeeID = e.EmployeeID,
                EmployeeName = e.EmployeeName,
                Email = e.Email,
                Salary = (decimal)e.Salary,
                JoinDate = e.JoiningDate,
                DepartmentID = e.DepartmentID
            });
        }

        public async Task<IEnumerable<EmployeeDto>> GetBySalaryRangeAsync(decimal min, decimal max)
        {
            var employees = await _employeeRepository.GetBySalaryRangeAsync(min, max);

            return employees.Select(e => new EmployeeDto
            {
                EmployeeID = e.EmployeeID,
                EmployeeName = e.EmployeeName,
                Email = e.Email,
                Salary = (decimal)e.Salary,
                JoinDate = e.JoiningDate,
                DepartmentID = e.DepartmentID
            });
        }

        public async Task CreateAsync(CreateEmployeeDto dto)
        {
            var department = await _departmentRepository.GetByIdAsync(dto.DepartmentID);

            if (department == null)
                throw new Exception("Department not found!!!");

            var employee = new Employee
            {
                EmployeeName = dto.EmployeeName,
                Email = dto.Email,
                Salary = (decimal)dto.Salary,
                JoiningDate = dto.JoinDate,
                DepartmentID = dto.DepartmentID
            };

            await _employeeRepository.AddAsync(employee);
            await _employeeRepository.SaveAsync();
        }

        public async Task UpdateAsync(int id, UpdateEmployeeDto dto)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
                throw new Exception("Employee not found!!!");

            employee.EmployeeName = dto.EmployeeName;
            employee.Email = dto.Email;
            employee.Salary = (decimal)dto.Salary;
            employee.JoiningDate = dto.JoinDate;
            employee.DepartmentID = dto.DepartmentID;

            await _employeeRepository.UpdateAsync(employee);
            await _employeeRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
                throw new Exception("Employee not found!!!");

            await _employeeRepository.DeleteAsync(employee);
            await _employeeRepository.SaveAsync();
        }
    }
}