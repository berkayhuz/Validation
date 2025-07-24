using FluentValidation;


using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class UppercaseValidator<T> : BaseValidator<T, string>
{
    public override string Name => nameof(UppercaseValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && value == value.ToUpperInvariant();
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.String_Uppercase;
}
