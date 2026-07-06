using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementAPI.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Department is required")]

        public string Department { get; set; }

        [Range(1000, 1000000, ErrorMessage = "Salary must be between 1000 and 1000000")]
        public decimal Salary { get; set; }
    }
}