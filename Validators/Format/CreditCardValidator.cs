using FluentValidation;
using FluentValidation.Validators;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class CreditCardValidator<T> : PropertyValidator<T, string>
{
    public override string Name => nameof(CreditCardValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return false;

        var digitsOnly = new string(value.Where(char.IsDigit).ToArray());

        if (digitsOnly.Length < 13 || digitsOnly.Length > 19)
            return false;

        var sum = 0;
        var alternate = false;

        for (var i = digitsOnly.Length - 1; i >= 0; i--)
        {
            var digit = digitsOnly[i] - '0';

            if (alternate)
            {
                digit *= 2;
                if (digit > 9)
                    digit -= 9;
            }

            sum += digit;
            alternate = !alternate;
        }

        return sum % 10 == 0;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.CreditCard_Invalid;
}
