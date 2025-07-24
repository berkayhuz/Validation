using FluentValidation;
using FluentValidation.Validators;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;
public sealed class TrimmedNotEmptyValidator<T> : PropertyValidator<T, string>
{
    public override string Name => nameof(TrimmedNotEmptyValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.String_TrimmedEmpty;
}
