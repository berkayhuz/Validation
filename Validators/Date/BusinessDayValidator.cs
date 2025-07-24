using FluentValidation;
using FluentValidation.Validators;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Date;

public sealed class BusinessDayValidator<T> : PropertyValidator<T, DateOnly>
{
    public override string Name => nameof(BusinessDayValidator<T>);

    public override bool IsValid(ValidationContext<T> context, DateOnly value)
    {
        var day = value.DayOfWeek;
        return day is >= DayOfWeek.Monday and <= DayOfWeek.Friday;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.Date_BusinessDay;
}
