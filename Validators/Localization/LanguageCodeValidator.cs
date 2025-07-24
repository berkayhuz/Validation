using FluentValidation;


using Validation.Core.Messages;

namespace Validation.Core.Validators.Localization;

public sealed class LanguageCodeValidator<T> : BaseValidator<T, string>
{
    private static readonly HashSet<string> _validLanguageCodes = new(StringComparer.OrdinalIgnoreCase)
    {
        "en", "tr", "de", "fr", "it", "es", "pt", "ru", "zh", "ja", "ko",
        "ar", "nl", "pl", "sv", "no", "da", "fi", "el", "cs", "ro", "hu"
        // Liste genişletilebilir
    };

    public override string Name => nameof(LanguageCodeValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && _validLanguageCodes.Contains(value.Trim().ToLower());
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.String_LanguageCode;
}
