using System.Text.RegularExpressions;

using FluentValidation;
using FluentValidation.Validators;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Network;
public sealed class PhoneNumberValidator<T> : PropertyValidator<T, string>
{
    private static readonly Regex _regex = new(@"^\+?[0-9\s\-]{7,20}$", RegexOptions.Compiled);

    public override string Name => nameof(PhoneNumberValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && _regex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.Phone_Invalid;
}
