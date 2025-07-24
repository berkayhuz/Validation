using FluentValidation;


using Validation.Core.Messages;

namespace Validation.Core.Validators.Date;

public sealed class WeekendValidator<T> : BaseValidator<T, DateOnly>
{
    public override string Name => nameof(WeekendValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, DateOnly value)
    {
        var dayOfWeek = value.DayOfWeek;
        return dayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.Date_Weekend;
}
