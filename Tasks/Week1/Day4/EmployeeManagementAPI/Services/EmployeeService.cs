using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Repositories;

namespace EmployeeManagementAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;

        public EmployeeService(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<Employee>> GetAll() => _repo.GetAll();

        public Task<Employee> Get(int id) => _repo.GetById(id);

        public Task<Employee> Create(Employee employee) => _repo.Add(employee);

        public Task<Employee> Update(Employee employee) => _repo.Update(employee);

        public Task<bool> Delete(int id) => _repo.Delete(id);
    }
}