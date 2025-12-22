using System.ComponentModel.DataAnnotations;
namespace n.DataAnnotationAttributes.ValidationAttributes;

// Validates that the age derived from the date of birth is within a specified range.
public class AgeRangeAttribute : ValidationAttribute
{
    // Private fields to store the minimum and maximum age limits.
    private readonly int _minAge;
    private readonly int _maxAge;

    // Constructor that initializes the minimum and maximum age limits.
    public AgeRangeAttribute(int minAge, int maxAge)
    {
        // Validate that the minimum age is not negative.
        if (minAge < 0)
            throw new ArgumentOutOfRangeException(nameof(minAge), "Minimum age cannot be negative.");

        // Validate that the maximum age is not less than the minimum age.
        if (maxAge < minAge)
            throw new ArgumentOutOfRangeException(nameof(maxAge), "Maximum age cannot be less than minimum age.");

        // Assign the validated age limits to the private fields.
        _minAge = minAge;
        _maxAge = maxAge;

        // Set a default error message that includes the age range.
        ErrorMessage = $"Age must be between {minAge} and {maxAge} years.";
    }

    // Overrides the IsValid method to implement custom age range validation.
    // value: The value of the property being validated (expected to be DateTime).
    // validationContext: The Context information about the validation operation
    // ValidationResult indicating whether validation succeeded or failed.
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        // Check if the value is of type DateTime (i.e., date of birth).
        if (value is DateTime dateOfBirth)
        {
            // Calculate the preliminary age by subtracting the birth year from the current year.
            var age = DateTime.Now.Year - dateOfBirth.Year;

            // Adjust the age if the birthday hasn't occurred yet this year.
            if (dateOfBirth > DateTime.Now.AddYears(-age))
            {
                age--;
            }

            // Check if the calculated age is outside the specified range.
            if (age < _minAge || age > _maxAge)
            {
                // Return a validation error with a message that includes the allowed age range.
                return new ValidationResult($"Employee age must be between {_minAge} and {_maxAge} years.");
            }
        }
        else
        {
            // If the value is not a DateTime, you might want to handle it accordingly.
            // For simplicity, we'll assume it's valid in this case.
            // Alternatively, you could return a ValidationResult indicating invalid usage.
        }

        // If all checks pass, return success.
        return ValidationResult.Success;
    }
}