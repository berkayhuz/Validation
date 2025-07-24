using FluentValidation;


using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class Base64Validator<T> : BaseValidator<T, string>
{
    public override string Name => nameof(Base64Validator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return false;

        try
        {
            // Trim + TryDecode + length check
            var _ = Convert.FromBase64String(value);
            return true;
        }
        catch
        {
            return false;
        }
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.Base64_Invalid;
}
