using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.API.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(100)]
        public string EmployeeName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public decimal Salary { get; set; }

        public DateTime JoiningDate { get; set; }

        public int DepartmentId { get; set; }

        public Department? Department { get; set; }
    }
}