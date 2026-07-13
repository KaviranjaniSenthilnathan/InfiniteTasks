using System.ComponentModel.DataAnnotations;
namespace EmployeeManagement.API.Model
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }

        [Required(ErrorMessage ="Must Enter Department Name !!!")]
        [StringLength(100)]
        public string DepartmentName { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public ICollection<Employee> ? Employees { get; set; }
    }
}
