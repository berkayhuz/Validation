using FluentValidation;
using FluentValidation.Validators;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Localization;

public sealed class CountryCodeValidator<T> : PropertyValidator<T, string>
{
    private static readonly HashSet<string> _validCountryCodes = new(StringComparer.OrdinalIgnoreCase)
    {
        "US", "GB", "DE", "FR", "IT", "ES", "TR", "CA", "AU", "JP", "CN", "RU", "BR",
        "IN", "MX", "NL", "SE", "CH", "NO", "DK", "FI", "BE", "PL", "GR", "PT", "KR",
        "AR", "ZA", "EG", "IL", "NZ", "UA", "AE", "SA", "IR", "IQ", "SY", "AZ", "GE",
        "CZ", "AT", "HU", "RO", "BG", "SK", "HR", "SI", "LT", "LV", "EE", "RS", "BA"
        // Liste isteğe göre genişletilebilir
    };

    public override string Name => nameof(CountryCodeValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && _validCountryCodes.Contains(value.Trim().ToUpper());
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.String_CountryCode;
}
