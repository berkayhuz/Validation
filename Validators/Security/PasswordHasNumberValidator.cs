using FluentValidation;


using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Security;

public sealed class PasswordHasNumberValidator<T> : BaseValidator<T, string>
{
    private static readonly Regex _numberRegex = new(@"\d", RegexOptions.Compiled);

    public override string Name => nameof(PasswordHasNumberValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && _numberRegex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.Password_NumberRequired;
}
