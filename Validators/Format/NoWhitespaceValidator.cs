using FluentValidation;


using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class NoWhitespaceValidator<T> : BaseValidator<T, string>
{
    public override string Name => nameof(NoWhitespaceValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && !value.Any(char.IsWhiteSpace);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.String_NoWhitespace;
}
