using FluentValidation;
using FluentValidation.Validators;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Security;

public sealed class SafeFileNameValidator<T> : PropertyValidator<T, string>
{
    private static readonly char[] _invalidFileNameChars = Path.GetInvalidFileNameChars();

    public override string Name => nameof(SafeFileNameValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && !value.Any(c => _invalidFileNameChars.Contains(c));
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.Security_InvalidFileName;
}
