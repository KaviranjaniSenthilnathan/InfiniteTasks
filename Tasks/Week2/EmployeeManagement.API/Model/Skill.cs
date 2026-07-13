using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.API.Model
{
    public class Skill
    {
        [Key]
        public int SkillID { get; set; }

        [Required]
        [StringLength(100)]
        public string SkillName { get; set; }

        public ICollection<EmployeeSkill>? EmployeeSkills { get; set; }

    }
}
