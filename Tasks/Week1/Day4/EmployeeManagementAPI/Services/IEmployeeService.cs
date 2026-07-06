using EmployeeManagementAPI.Models;

namespace EmployeeManagementAPI.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> Get(int id);
        Task<Employee> Create(Employee employee);
        Task<Employee> Update(Employee employee);
        Task<bool> Delete(int id);
    }
}