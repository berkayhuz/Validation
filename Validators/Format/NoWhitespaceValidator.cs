using FluentValidation;
using FluentValidation.Validators;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class NoWhitespaceValidator<T> : PropertyValidator<T, string>
{
    public override string Name => nameof(NoWhitespaceValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && !value.Any(char.IsWhiteSpace);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.String_NoWhitespace;
}
