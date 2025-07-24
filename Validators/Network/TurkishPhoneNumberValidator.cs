using FluentValidation;
using FluentValidation.Validators;

using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Network;

public sealed class TurkishPhoneNumberValidator<T> : PropertyValidator<T, string>
{
    // Desteklenen formatlar: 05XXXXXXXXX, +905XXXXXXXXX, 905XXXXXXXXX
    private static readonly Regex _turkishPhoneRegex = new(@"^(?:\+90|90|0)?5\d{9}$", RegexOptions.Compiled);

    public override string Name => nameof(TurkishPhoneNumberValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && _turkishPhoneRegex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.Phone_TurkishMobile;
}
