using FluentValidation;
using FluentValidation.Validators;

using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class CamelCaseValidator<T> : PropertyValidator<T, string>
{
    private static readonly Regex _camelRegex = new(@"^[a-z]+(?:[A-Z][a-z0-9]*)*$", RegexOptions.Compiled);

    public override string Name => nameof(CamelCaseValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && _camelRegex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.String_CamelCase;
}
