using System.Globalization;

using FluentValidation;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Localization;

public sealed class LanguageTagValidator<T> : BaseValidator<T, string>
{
    public override string Name => nameof(LanguageTagValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return false;

        try
        {
            _ = CultureInfo.GetCultureInfoByIetfLanguageTag(value);
            return true;
        }
        catch
        {
            return false;
        }
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.Localization_InvalidLanguageTag;
}
