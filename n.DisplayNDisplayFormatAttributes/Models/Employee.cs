namespace n.DisplayNDisplayFormatAttributes.Models;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class Employee
{
    public int Id { get; set; }

    // Applying Display attribute to change the label as Full Name

    [Display(Name = "Full Name")]
    public string FullName { get; set; }

    // Display "Gender Not Specified" if the value is null

    [DisplayFormat(NullDisplayText = "Gender Not Specified")]
    public string Gender { get; set; }

    public int Age { get; set; }

    // Format the date as "dd/MM/yyyy"
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    // Applying Display attribute to change the label as Date of Joining
    [Display(Name = "Date of Joining")]
    public DateTime DateOfJoining { get; set; }

    // Change the display name and specify email data type
    [Display(Name = "Email Address")]
    [DataType(DataType.EmailAddress)]
    public string EmailAddress { get; set; }

    // Formats Salary as currency
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    public decimal Salary { get; set; }

    // Change the display name and specify URL data type
    [Display(Name = "Personal Website")]
    [DataType(DataType.Url)]
    public string? PersonalWebsite { get; set; }

    // Formats PerformanceRating to two decimal places
    [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
    // Applying Display attribute to change the label as Personal Website
    [Display(Name = "Personal Website")]
    public double PerformanceRating { get; set; }

    // Formats DateOfBirth as "yyyy-MM-dd"
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    // Applying Display attribute to change the label as Date of Birth
    [Display(Name = "Date of Birth")]
    public DateTime DateOfBirth { get; set; }

    // Display "No Description Available" if null or empty
    [DisplayFormat(NullDisplayText = "No Description Available")]
    public string? JobDescription { get; set; }

    // Formats LastDateOfWorking as "MMM dd, yyyy" or displays "N/A" if null or empty
    [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}", NullDisplayText = "N/A", ApplyFormatInEditMode = true)]
    // Applying DisplayName attribute to change the label as Last Date Of Working
    [DisplayName("Last Date Of Working")]
    public DateTime? LastDateOfWorking { get; set; }
}