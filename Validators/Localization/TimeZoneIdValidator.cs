using FluentValidation;


using Validation.Core.Messages;

namespace Validation.Core.Validators.Localization;

public sealed class TimeZoneIdValidator<T> : BaseValidator<T, string>
{
    public override string Name => nameof(TimeZoneIdValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value)
            && TimeZoneInfo.GetSystemTimeZones().Any(tz => string.Equals(tz.Id, value, StringComparison.OrdinalIgnoreCase));
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.Localization_InvalidTimeZone;
}
