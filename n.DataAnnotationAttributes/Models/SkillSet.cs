using System.ComponentModel.DataAnnotations;
namespace n.DataAnnotationAttributes.Models;

public class SkillSet
{
    [Key]
    public int SkillSetId { get; set; }

    [Required(ErrorMessage = "Skill Name is required")]
    [StringLength(50)]
    public string? SkillName { get; set; }

    // Navigation property
    public List<Employee>? Employees { get; set; }
}