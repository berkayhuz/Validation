using FluentValidation;


using Validation.Core.Messages;

namespace Validation.Core.Validators.Security;

public sealed class SafeFileNameValidator<T> : BaseValidator<T, string>
{
    private static readonly char[] _invalidFileNameChars = Path.GetInvalidFileNameChars();

    public override string Name => nameof(SafeFileNameValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && !value.Any(c => _invalidFileNameChars.Contains(c));
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.Security_InvalidFileName;
}
