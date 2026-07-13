using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.API.DTOs.Department
{
    public class UpdateDepartmentDto
    {
        [Required(ErrorMessage = "Department Name is required")]
        [StringLength(100)]
        public string DepartmentName { get; set; } = string.Empty;
    }
} 