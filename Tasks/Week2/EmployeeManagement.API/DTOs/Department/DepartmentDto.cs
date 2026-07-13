namespace EmployeeManagement.API.DTOs.Department
{
    public class DepartmentDto
    {
        public int DepartmentID { get; set; }

        public string DepartmentName { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }
    }
}