using FluentValidation;


using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class LowercaseValidator<T> : BaseValidator<T, string>
{
    public override string Name => nameof(LowercaseValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && value == value.ToLowerInvariant();
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.String_Lowercase;
}
