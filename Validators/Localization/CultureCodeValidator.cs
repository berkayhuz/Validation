using FluentValidation;


using System.Globalization;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Localization;

public sealed class CultureCodeValidator<T> : BaseValidator<T, string>
{
    public override string Name => nameof(CultureCodeValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value)
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
        ValidationResource.Localization_InvalidCulture;
}
