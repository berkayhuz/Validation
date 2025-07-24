using FluentValidation;
using FluentValidation.Validators;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class EndsWithValidator<T> : PropertyValidator<T, string>
{
    private readonly string _suffix;
    private readonly StringComparison _comparison;

    public EndsWithValidator(string suffix, bool caseSensitive = false)
    {
        _suffix = suffix;
        _comparison = caseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;
    }

    public override string Name => nameof(EndsWithValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && value.EndsWith(_suffix, _comparison);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.String_EndsWith;
}
