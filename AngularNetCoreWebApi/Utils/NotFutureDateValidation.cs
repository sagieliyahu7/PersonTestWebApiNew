using System.ComponentModel.DataAnnotations;

namespace PersonTestWebApi.Utils
{
    public class NotFutureDateValidation : ValidationAttribute
    {
        protected override ValidationResult
                IsValid(object value, ValidationContext validationContext)
        {
            DateTime? date;
            if ((date = value as DateTime?) != null && date <= DateTime.Now)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult
                    ("Invalid date.");
            }
        }
    }
}
