using n.DataAnnotationAttributes.Data;
using Microsoft.EntityFrameworkCore;
namespace n.DataAnnotationAttributes.Models;

public class GenerateEmailSuggestions
{
    private readonly ApplicationDbContext _context;

    public GenerateEmailSuggestions(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<string> GenerateUniqueEmailsAsync(string baseEmail, int count = 2)
    {
        var suggestions = new List<string>();
        string emailPrefix = baseEmail.Split('@')[0];
        string emailDomain = baseEmail.Split('@')[1];
        string suggestion;

        while (suggestions.Count < count)
        {
            do
            {
                suggestion = $"{emailPrefix}{new Random().Next(100, 999)}@{emailDomain}";
                //Use AnyAsync to asynchronously check if the email exists
            } while (await _context.Employees.AnyAsync(u => u.Email == suggestion) || suggestions.Contains(suggestion));

            suggestions.Add(suggestion);
        }

        return string.Join(", ", suggestions);
    }
}
