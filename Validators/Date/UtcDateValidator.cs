using FluentValidation;


using Validation.Core.Messages;

namespace Validation.Core.Validators.Date;

public sealed class UtcDateValidator<T> : BaseValidator<T, DateTime>
{
    public override string Name => nameof(UtcDateValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, DateTime value)
    {
        return value.Kind == DateTimeKind.Utc;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.Date_Utc;
}
