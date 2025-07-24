using FluentValidation;


using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class OnlyLettersValidator<T> : BaseValidator<T, string>
{
    private static readonly Regex _lettersRegex = new(@"^[a-zA-ZğüşöçİĞÜŞÖÇ\s]+$", RegexOptions.Compiled);

    public override string Name => nameof(OnlyLettersValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && _lettersRegex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.String_OnlyLetters;
}
