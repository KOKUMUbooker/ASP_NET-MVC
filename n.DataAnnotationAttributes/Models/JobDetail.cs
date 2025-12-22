using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace n.DataAnnotationAttributes.Models;

public class JobDetail
{
    [Key]
    public int JobDetailId { get; set; }

    [Required(ErrorMessage = "Job Title is required")]
    public int JobTitleId { get; set; }

    [Required(ErrorMessage = "Department is required")]
    public int DepartmentId { get; set; }
    [Required(ErrorMessage = "Department is required")]
    public int EmployeeId { get; set; }

    [DataType(DataType.Currency)]
    [Range(30000, 200000, ErrorMessage = "Salary must be between 30,000 and 200,000")]
    [Column(TypeName ="decimal(18,2)")]
    public decimal Salary { get; set; }

    // Navigation properties
    public Department? Department { get; set; }
    public Employee? Employee { get; set; }
    public JobTitle? JobTitle { get; set; }
}