using n.DataAnnotationAttributes.Data;
using n.DataAnnotationAttributes.Models;
using System.ComponentModel.DataAnnotations;

namespace n.DataAnnotationAttributes.ValidationAttributes;

public class UniqueEmailAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        //Get the ApplicationDbContext Instance from the DI Container
        var _context = validationContext.GetService<ApplicationDbContext>();

        var email = value as string;
        if (_context.Employees.Any(u => u.Email == email))
        {
            //Get the GenerateEmailSuggestions Instance from the DI Container
            var _generateSuggestions = validationContext.GetService<GenerateEmailSuggestions>();

            //The second parameter will decide the number of unique suggestions to be generated
            var suggestedEmails = _generateSuggestions?.GenerateUniqueEmailsAsync(email, 3).Result;

            return new ValidationResult($"Email is already in use. Try anyone of these: {suggestedEmails}");
        }

        return ValidationResult.Success;
    }
}