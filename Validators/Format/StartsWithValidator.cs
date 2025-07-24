using FluentValidation;


using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class StartsWithValidator<T> : BaseValidator<T, string>
{
    private readonly string _prefix;
    private readonly StringComparison _comparison;

    public StartsWithValidator(string prefix, bool caseSensitive = false)
    {
        _prefix = prefix;
        _comparison = caseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;
    }

    public override string Name => nameof(StartsWithValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && value.StartsWith(_prefix, _comparison);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.String_StartsWith;
}
