using System.ComponentModel.DataAnnotations;

namespace n.WhitelistNBlacklistDataAnnotation.ValidationModels;

public class WhitelistAttribute : ValidationAttribute
{
    public string[] AllowedValues { get; set; }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value != null && AllowedValues.Contains(value.ToString(), StringComparer.OrdinalIgnoreCase))
        {
            return ValidationResult.Success;
        }

        return new ValidationResult($"The value {value} is not allowed.");
    }
}