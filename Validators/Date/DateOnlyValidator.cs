using FluentValidation;
using FluentValidation.Validators;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Date;

public sealed class DateOnlyValidator<T> : PropertyValidator<T, DateTime>
{
    public override string Name => nameof(DateOnlyValidator<T>);

    public override bool IsValid(ValidationContext<T> context, DateTime value)
    {
        return value.TimeOfDay == TimeSpan.Zero;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.Date_Only;
}
