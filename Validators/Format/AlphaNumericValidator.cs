using FluentValidation;
using FluentValidation.Validators;

using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class AlphaNumericValidator<T> : PropertyValidator<T, string>
{
    private static readonly Regex _alphaNumRegex = new(@"^[a-zA-Z0-9]+$", RegexOptions.Compiled);

    public override string Name => nameof(AlphaNumericValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && _alphaNumRegex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.String_AlphaNumericOnly;
}
