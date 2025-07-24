using FluentValidation;


using Validation.Core.Messages;

namespace Validation.Core.Validators.Date;

public sealed class BusinessDayValidator<T> : BaseValidator<T, DateOnly>
{
    public override string Name => nameof(BusinessDayValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, DateOnly value)
    {
        var day = value.DayOfWeek;
        return day is >= DayOfWeek.Monday and <= DayOfWeek.Friday;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.Date_BusinessDay;
}
