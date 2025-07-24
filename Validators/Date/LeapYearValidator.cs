using FluentValidation;


using Validation.Core.Messages;

namespace Validation.Core.Validators.Date;

public sealed class LeapYearValidator<T> : BaseValidator<T, DateOnly>
{
    public override string Name => nameof(LeapYearValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, DateOnly value)
    {
        var year = value.Year;
        return DateTime.IsLeapYear(year);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.Date_LeapYear;
}
