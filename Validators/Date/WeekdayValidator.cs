using FluentValidation;
using FluentValidation.Validators;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Date;

public sealed class WeekdayValidator<T> : PropertyValidator<T, DateOnly>
{
    public override string Name => nameof(WeekdayValidator<T>);

    public override bool IsValid(ValidationContext<T> context, DateOnly value)
    {
        var dayOfWeek = value.DayOfWeek;
        return dayOfWeek is >= DayOfWeek.Monday and <= DayOfWeek.Friday;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.Date_Weekday;
}
