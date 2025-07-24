using FluentValidation;
using FluentValidation.Validators;

using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Security;

public sealed class PasswordHasNumberValidator<T> : PropertyValidator<T, string>
{
    private static readonly Regex _numberRegex = new(@"\d", RegexOptions.Compiled);

    public override string Name => nameof(PasswordHasNumberValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && _numberRegex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.Password_NumberRequired;
}
