using FluentValidation;
using FluentValidation.Validators;

using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class OnlyLettersValidator<T> : PropertyValidator<T, string>
{
    private static readonly Regex _lettersRegex = new(@"^[a-zA-ZğüşöçİĞÜŞÖÇ\s]+$", RegexOptions.Compiled);

    public override string Name => nameof(OnlyLettersValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && _lettersRegex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.String_OnlyLetters;
}
