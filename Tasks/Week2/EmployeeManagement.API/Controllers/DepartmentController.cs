
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.API.DTOs.Department;
using EmployeeManagement.API.Services.Interfaces;

namespace EmployeeManagement.API.Controllers
{
    [Authorize(Roles = "Admin,HR,Maganer,Tech Lead, IT")]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _departmentService.GetAllAsync();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var department = await _departmentService.GetByIdAsync(id);

            if (department == null)
                return NotFound();

            return Ok(department);
        }

        [HttpPost]

        public async Task<IActionResult> Create(CreateDepartmentDto dto)
        {

            await _departmentService.CreateAsync(dto);
            return Ok("Department Created Successfully !!!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateDepartmentDto dto)
        {
            await _departmentService.UpdateAsync(id, dto);
            return Ok("Department Updated Successfully !!!");
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _departmentService.DeleteAsync(id);
            return Ok("Department Deleted Successfully !!!");
        }
    }
}