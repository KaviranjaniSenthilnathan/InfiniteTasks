namespace EmployeeManagement.API.DTOs.Employee
{
    public class EmployeeDto
    {
        public int EmployeeID { get; set; }

        public string EmployeeName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public decimal Salary { get; set; }

        public DateTime JoinDate { get; set; }

        public int DepartmentID { get; set; }

        public string DepartmentName { get; set; } = string.Empty;
    }
}