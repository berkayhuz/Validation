using FluentValidation;
using FluentValidation.Validators;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Date;

public sealed class LeapYearValidator<T> : PropertyValidator<T, DateOnly>
{
    public override string Name => nameof(LeapYearValidator<T>);

    public override bool IsValid(ValidationContext<T> context, DateOnly value)
    {
        var year = value.Year;
        return DateTime.IsLeapYear(year);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.Date_LeapYear;
}
