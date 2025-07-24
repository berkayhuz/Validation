using FluentValidation;
using FluentValidation.Validators;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Localization;

public sealed class CurrencyValidator<T> : PropertyValidator<T, string>
{
    // ISO 4217 standardındaki yaygın kodlar (dilersen external resource'tan yükleyebilirim)
    private static readonly HashSet<string> _validCurrencies =
    [
        "USD", "EUR", "TRY", "GBP", "JPY", "CHF", "CAD", "AUD", "CNY", "SEK",
        "NOK", "DKK", "RUB", "AED", "SAR", "KWD", "INR", "BRL", "ZAR", "MXN"
    ];

    public override string Name => nameof(CurrencyValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value)
               && value.Length == 3
               && _validCurrencies.Contains(value.ToUpper());
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.Currency_Invalid;
}
