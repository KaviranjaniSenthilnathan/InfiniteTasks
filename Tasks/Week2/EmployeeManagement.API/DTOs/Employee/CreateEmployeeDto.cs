using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.API.DTOs.Employee
{
    public class CreateEmployeeDto
    {
        [Required]
        [StringLength(100)]
        public string EmployeeName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Range(10000, 1000000)]
        public decimal Salary { get; set; }

        public DateTime JoinDate { get; set; }

        [Required]
        public int DepartmentID { get; set; }
    }
}