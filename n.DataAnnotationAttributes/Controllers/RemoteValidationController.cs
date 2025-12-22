using n.DataAnnotationAttributes.Data;
using n.DataAnnotationAttributes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace n.DataAnnotationAttributes.Controllers;

public class RemoteValidationController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly GenerateEmailSuggestions _generateSuggestions;

    public RemoteValidationController(ApplicationDbContext context, GenerateEmailSuggestions generateSuggestions)
    {
        _context = context;
        _generateSuggestions = generateSuggestions;
    }

    // Checks if the provided email is available. If not, returns suggestions.
    // Email: The email to validate
    // Returns a JSON result indicating availability or suggestions
    [AcceptVerbs("GET", "POST")]
    public async Task<IActionResult> IsEmailAvailable(string email)
    {
        // Check if the email is empty
        if (string.IsNullOrEmpty(email))
        {
            return Json("Please enter a valid email address.");
        }

        // Validate the email format
        var emailAttribute = new EmailAddressAttribute();
        if (!emailAttribute.IsValid(email))
        {
            return Json("Please enter a valid email address.");
        }

        // Check if the email is already in use (case-insensitive)
        var emailExists = await _context.Employees.AnyAsync(u => u.Email.ToLower() == email.ToLower());
        if (emailExists)
        {
            //The second parameter will decide the number of unique suggestions to be generated
            var suggestedEmails = await _generateSuggestions.GenerateUniqueEmailsAsync(email, 3);
            return Json($"Email is already in use. Try anyone of these: {suggestedEmails}");
        }

        // If the email is available
        return Json(true);  // Indicates success to jQuery Unobtrusive Validation
    }
}
