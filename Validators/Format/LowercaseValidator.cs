using FluentValidation;
using FluentValidation.Validators;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class LowercaseValidator<T> : PropertyValidator<T, string>
{
    public override string Name => nameof(LowercaseValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && value == value.ToLowerInvariant();
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.String_Lowercase;
}
