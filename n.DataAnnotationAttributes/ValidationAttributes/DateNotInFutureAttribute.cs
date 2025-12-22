using System.ComponentModel.DataAnnotations;

namespace n.DataAnnotationAttributes.ValidationAttributes;

//Validates that the provided date is not in the future.
public class DateNotInFutureAttribute : ValidationAttribute
{
    // Constructor that sets the default error message.
    public DateNotInFutureAttribute()
    {
        // Set a default error message to be displayed when validation fails.
        ErrorMessage = "Date of Joining cannot be in the future.";
    }

    // Overrides the IsValid method to implement custom validation logic.
    // value: The value of the property being validated
    // validationContext: The Context information about the validation operation
    // ValidationResult indicating whether validation succeeded or failed
#pragma warning disable CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
    protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
#pragma warning restore CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
    {
        // If the value is null, assume that another attribute (e.g., [Required]) handles it.
        if (value == null)
            return ValidationResult.Success;

        // Check if the value is of type DateTime.
        if (value is DateTime dateValue)
        {
            // Compare the provided date with the current date and time.
            if (dateValue > DateTime.Now)
            {
                // If the date is in the future, return a validation error with the specified message.
                return new ValidationResult(ErrorMessage);
            }
        }
        else
        {
            // If the value is not a DateTime, return a validation error indicating improper usage.
            return new ValidationResult("Invalid data type for DateNotInFutureAttribute.");
        }

        // If all checks pass, return success.
        return ValidationResult.Success;
    }
}
