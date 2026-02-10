using System;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Validation
{
    public class NotFutureYearAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            if (value is int year)
            {
                if (year > DateTime.Now.Year)
                {
                    return new ValidationResult(ErrorMessage
                        ?? "Рік не може бути з майбутнього");
                }
            }

            return ValidationResult.Success;
        }
    }
}
