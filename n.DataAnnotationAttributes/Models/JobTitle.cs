using System.ComponentModel.DataAnnotations;
namespace n.DataAnnotationAttributes.Models;

public class JobTitle
{
    [Key]
    public int JobTitleId { get; set; }

    [Required]
    [StringLength(100)]
    public string? TitleName { get; set; }
}