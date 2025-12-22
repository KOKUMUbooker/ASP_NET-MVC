using System.ComponentModel.DataAnnotations;

namespace n.WhitelistNBlacklistDataAnnotation.ValidationModels;

public class OffensiveWordBlacklistAttribute : ValidationAttribute
{
    public string[] DisallowedWords { get; set; }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is string commentText)
        {
            var foundWords = new List<string>();

            // Check each word in the list of disallowed words
            foreach (var word in DisallowedWords)
            {
                // Case insensitive check if the comment contains the disallowed word
                if (commentText.Contains(word, StringComparison.OrdinalIgnoreCase))
                {
                    foundWords.Add(word);
                }
            }

            // If any offensive words are found, return a ValidationResult with all offending words
            if (foundWords.Any())
            {
                return new ValidationResult($"The comment contains disallowed words: {string.Join(", ", foundWords)}");
            }
        }
        return ValidationResult.Success;
    }
}