using FluentValidation;
using FluentValidation.Validators;

using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Security;

public sealed class PasswordHasUppercaseValidator<T> : PropertyValidator<T, string>
{
    private static readonly Regex _uppercaseRegex = new(@"[A-Z]", RegexOptions.Compiled);

    public override string Name => nameof(PasswordHasUppercaseValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && _uppercaseRegex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.Password_UppercaseRequired;
}
