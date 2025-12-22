using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace n.DataAnnotationAttributes.Models
{
    //Creating Uniqe Index on Email Column to avoid Duplicate Emails
    [Index(nameof(Email), Name = "IX_Employees_Unique_Email", IsUnique = true)]
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        // Basic Information
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "First name should be between 2 and 30 characters")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(30, ErrorMessage = "Last name cannot exceed 30 characters")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Joining Date is required")]
        [DataType(DataType.Date)]
        public DateTime? JoiningDate { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public Gender? Gender { get; set; }

        // Account Information
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password should be at least 6 characters")]
        public string? Password { get; set; }

        // Address Information
        public Address? Address { get; set; }

        // Job Details
        public JobDetail? JobDetail { get; set; }

        // Skills (Many-to-Many)
        public ICollection<SkillSet>? SkillSets { get; set; }
    }
}