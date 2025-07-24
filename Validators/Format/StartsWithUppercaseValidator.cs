using FluentValidation;


using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class StartsWithUppercaseValidator<T> : BaseValidator<T, string>
{
    private static readonly Regex _uppercaseStartRegex = new(@"^[A-ZÇĞİÖŞÜ]", RegexOptions.Compiled);

    public override string Name => nameof(StartsWithUppercaseValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && _uppercaseStartRegex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.String_StartsWithUppercase;
}
