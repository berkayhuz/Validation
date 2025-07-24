using FluentValidation;
using FluentValidation.Validators;

using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Security;

public sealed class PasswordComplexityValidator<T> : PropertyValidator<T, string>
{
    private readonly int _minLength;

    private static readonly Regex _hasLetter = new(@"[a-zA-Z]", RegexOptions.Compiled);
    private static readonly Regex _hasDigit = new(@"\d", RegexOptions.Compiled);
    private static readonly Regex _hasSymbol = new(@"[!@#\$%\^&\*\(\)_\+\-=\[\]\{\};:'"",.<>\/\\|`~]", RegexOptions.Compiled);

    public PasswordComplexityValidator(int minLength = 8)
    {
        _minLength = minLength;
    }

    public override string Name => nameof(PasswordComplexityValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value)
            && value.Length >= _minLength
            && _hasLetter.IsMatch(value)
            && _hasDigit.IsMatch(value)
            && _hasSymbol.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        string.Format(ValidationMessages.Security_PasswordComplexity, _minLength);
}
