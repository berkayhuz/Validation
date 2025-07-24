using FluentValidation;
using FluentValidation.Validators;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Date;

public sealed class DateNotInPastValidator<T> : PropertyValidator<T, DateTime>
{
    public override string Name => nameof(DateNotInPastValidator<T>);

    public override bool IsValid(ValidationContext<T> context, DateTime value)
    {
        return value >= DateTime.UtcNow;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.Date_InPast;
}
