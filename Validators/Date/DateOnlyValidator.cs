using FluentValidation;


using Validation.Core.Messages;

namespace Validation.Core.Validators.Date;

public sealed class DateOnlyValidator<T> : BaseValidator<T, DateTime>
{
    public override string Name => nameof(DateOnlyValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, DateTime value)
    {
        return value.TimeOfDay == TimeSpan.Zero;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.Date_Only;
}
