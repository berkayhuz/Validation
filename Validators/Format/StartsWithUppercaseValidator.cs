using FluentValidation;
using FluentValidation.Validators;

using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class StartsWithUppercaseValidator<T> : PropertyValidator<T, string>
{
    private static readonly Regex _uppercaseStartRegex = new(@"^[A-ZÇĞİÖŞÜ]", RegexOptions.Compiled);

    public override string Name => nameof(StartsWithUppercaseValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && _uppercaseStartRegex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.String_StartsWithUppercase;
}
