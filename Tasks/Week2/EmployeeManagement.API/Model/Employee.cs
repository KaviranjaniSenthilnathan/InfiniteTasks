using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EmployeeManagement.API.Model
{
    public class Employee
    {
        [Key]
        public int EmployeeID {  get; set; }
        [Required(ErrorMessage ="Must Enter Employee Name!!!")]
        public string EmployeeName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage ="Must Enter Salary!!!")]
        [Range(10000,1000000)]
        public decimal Salary { get; set; }
        public DateTime JoiningDate {  get; set; }
        public int DepartmentID { get; set; }

        [ForeignKey("DepartmentID")]
        public Department? Department {  get; set; }
        public ICollection<EmployeeSkill> ? EmployeeSkills { get; set; }
    }
}
