using FluentValidation;
using FluentValidation.Validators;

using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class NoSpecialCharactersValidator<T> : PropertyValidator<T, string>
{
    private static readonly Regex _noSpecialCharsRegex = new(@"^[a-zA-Z0-9\s]+$", RegexOptions.Compiled);

    public override string Name => nameof(NoSpecialCharactersValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && _noSpecialCharsRegex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.String_NoSpecialCharacters;
}
