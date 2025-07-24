using FluentValidation;
using FluentValidation.Validators;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Date;

public sealed class WeekendValidator<T> : PropertyValidator<T, DateOnly>
{
    public override string Name => nameof(WeekendValidator<T>);

    public override bool IsValid(ValidationContext<T> context, DateOnly value)
    {
        var dayOfWeek = value.DayOfWeek;
        return dayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.Date_Weekend;
}
