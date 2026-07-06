using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.API.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [Required]
        [StringLength(100)]
        public string DepartmentName { get; set; }

        public DateTime CreatedDate { get; set; }

        public ICollection<Employee>? Employees { get; set; }
    }
}