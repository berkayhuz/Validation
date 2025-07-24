using FluentValidation;


using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class PascalCaseValidator<T> : BaseValidator<T, string>
{
    private static readonly Regex _pascalRegex = new(@"^([A-Z][a-z0-9]*)+$", RegexOptions.Compiled);

    public override string Name => nameof(PascalCaseValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && _pascalRegex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.String_PascalCase;
}
