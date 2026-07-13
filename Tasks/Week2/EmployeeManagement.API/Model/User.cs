using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EmployeeManagement.API.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Must Enter UserName !!!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Must Enter Email Address !!!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Must Enter Password !!!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Must Enter Role !!!")]
        public string Role { get; set; }
    }
}
