using System.ComponentModel.DataAnnotations;

namespace IntlIdInputBlazor;

public class IntlIdAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is null)
        {
            return new ValidationResult(ErrorMessage, new[] { validationContext.MemberName });
        }

        if (value is not IntlId intlId)
        {
            throw new InvalidOperationException($"{nameof(IntlIdAttribute)} can only validate {nameof(intlId)}");
        }
        return intlId.IsValid ? ValidationResult.Success : new ValidationResult(ErrorMessage, new[] { validationContext.MemberName });
    }
}