using FluentValidation;
using FluentValidation.Validators;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Localization;

public sealed class TimeZoneIdValidator<T> : PropertyValidator<T, string>
{
    public override string Name => nameof(TimeZoneIdValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value)
            && TimeZoneInfo.GetSystemTimeZones().Any(tz => string.Equals(tz.Id, value, StringComparison.OrdinalIgnoreCase));
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.Localization_InvalidTimeZone;
}
