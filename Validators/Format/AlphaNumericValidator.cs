using FluentValidation;


using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class AlphaNumericValidator<T> : BaseValidator<T, string>
{
    private static readonly Regex _alphaNumRegex = new(@"^[a-zA-Z0-9]+$", RegexOptions.Compiled);

    public override string Name => nameof(AlphaNumericValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && _alphaNumRegex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.String_AlphaNumericOnly;
}
