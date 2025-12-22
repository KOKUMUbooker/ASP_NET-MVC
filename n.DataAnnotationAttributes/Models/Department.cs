using System.ComponentModel.DataAnnotations;
namespace n.DataAnnotationAttributes.Models;

public class Department
{
    [Key]
    public int DepartmentId { get; set; }

    [Required(ErrorMessage = "Department Name is required")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Department name should be between 2 and 50 characters")]
    public string? Name { get; set; }
}