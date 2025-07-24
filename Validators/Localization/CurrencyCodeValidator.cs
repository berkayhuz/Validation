using FluentValidation;
using FluentValidation.Validators;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Localization;

public sealed class CurrencyCodeValidator<T> : PropertyValidator<T, string>
{
    private static readonly HashSet<string> _validCurrencyCodes = new(StringComparer.OrdinalIgnoreCase)
    {
        "USD", "EUR", "TRY", "GBP", "JPY", "CNY", "CHF", "AUD", "CAD",
        "RUB", "INR", "BRL", "MXN", "SEK", "NOK", "DKK", "PLN", "ZAR"
        // Liste genişletilebilir
    };

    public override string Name => nameof(CurrencyCodeValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && _validCurrencyCodes.Contains(value.Trim().ToUpper());
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.String_CurrencyCode;
}
