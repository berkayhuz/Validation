using FluentValidation;
using FluentValidation.Validators;

using System.Globalization;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Localization;

public sealed class CultureCodeValidator<T> : PropertyValidator<T, string>
{
    public override string Name => nameof(CultureCodeValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return false;

        try
        {
            _ = new CultureInfo(value);
            return true;
        }
        catch
        {
            return false;
        }
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.Localization_InvalidCulture;
}
