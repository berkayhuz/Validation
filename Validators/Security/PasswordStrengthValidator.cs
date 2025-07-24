using FluentValidation;
using FluentValidation.Validators;

using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Security;

public sealed class PasswordStrengthValidator<T> : PropertyValidator<T, string>
{
    private static readonly Regex _upperCaseRegex = new("[A-Z]", RegexOptions.Compiled);
    private static readonly Regex _lowerCaseRegex = new("[a-z]", RegexOptions.Compiled);
    private static readonly Regex _digitRegex = new("[0-9]", RegexOptions.Compiled);
    private static readonly Regex _specialCharRegex = new(@"[\W_]", RegexOptions.Compiled);

    private readonly int _minLength;

    public PasswordStrengthValidator(int minLength = 8)
    {
        _minLength = minLength;
    }

    public override string Name => nameof(PasswordStrengthValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length < _minLength)
            return false;

        return _upperCaseRegex.IsMatch(value)
            && _lowerCaseRegex.IsMatch(value)
            && _digitRegex.IsMatch(value)
            && _specialCharRegex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.Password_Weak;
}
