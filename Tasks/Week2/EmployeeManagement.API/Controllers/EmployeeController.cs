using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.API.DTOs.Employee;
using EmployeeManagement.API.Services.Interfaces;

namespace EmployeeManagement.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _employeeService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeDto dto)
        {
            await _employeeService.CreateAsync(dto);
            return Ok("Employee Created Successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateEmployeeDto dto)
        {
            await _employeeService.UpdateAsync(id, dto);
            return Ok("Employee Updated Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.DeleteAsync(id);
            return Ok("Employee Deleted Successfully");
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string name)
        {
            return Ok(await _employeeService.SearchByNameAsync(name));
        }

        [HttpGet("department/{departmentId}")]
        public async Task<IActionResult> GetByDepartment(int departmentId)
        {
            return Ok(await _employeeService.GetByDepartmentAsync(departmentId));
        }

        [HttpGet("salary")]
        public async Task<IActionResult> GetBySalary(decimal min, decimal max)
        {
            return Ok(await _employeeService.GetBySalaryRangeAsync(min, max));
        }
    }
}