using FluentValidation;
using FluentValidation.Validators;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class UppercaseValidator<T> : PropertyValidator<T, string>
{
    public override string Name => nameof(UppercaseValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && value == value.ToUpperInvariant();
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.String_Uppercase;
}
