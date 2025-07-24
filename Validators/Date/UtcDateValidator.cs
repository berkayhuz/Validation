using FluentValidation;
using FluentValidation.Validators;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Date;

public sealed class UtcDateValidator<T> : PropertyValidator<T, DateTime>
{
    public override string Name => nameof(UtcDateValidator<T>);

    public override bool IsValid(ValidationContext<T> context, DateTime value)
    {
        return value.Kind == DateTimeKind.Utc;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.Date_Utc;
}
