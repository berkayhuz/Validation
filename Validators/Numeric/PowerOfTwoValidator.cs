using FluentValidation;


using Validation.Core.Messages;

namespace Validation.Core.Validators.Numeric;

public sealed class PowerOfTwoValidator<T> : BaseValidator<T, int>
{
    public override string Name => nameof(PowerOfTwoValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, int value)
    {
        return value > 0 && (value & value - 1) == 0;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.Number_PowerOfTwo;
}
