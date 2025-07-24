using FluentValidation;


using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Security;

public sealed class PasswordHasUppercaseValidator<T> : BaseValidator<T, string>
{
    private static readonly Regex _uppercaseRegex = new(@"[A-Z]", RegexOptions.Compiled);

    public override string Name => nameof(PasswordHasUppercaseValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && _uppercaseRegex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.Password_UppercaseRequired;
}
