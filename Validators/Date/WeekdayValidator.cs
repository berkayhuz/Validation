using FluentValidation;


using Validation.Core.Messages;

namespace Validation.Core.Validators.Date;

public sealed class WeekdayValidator<T> : BaseValidator<T, DateOnly>
{
    public override string Name => nameof(WeekdayValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, DateOnly value)
    {
        var dayOfWeek = value.DayOfWeek;
        return dayOfWeek is >= DayOfWeek.Monday and <= DayOfWeek.Friday;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.Date_Weekday;
}
