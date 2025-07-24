using FluentValidation;
using FluentValidation.Validators;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Numeric;

public sealed class PowerOfTwoValidator<T> : PropertyValidator<T, int>
{
    public override string Name => nameof(PowerOfTwoValidator<T>);

    public override bool IsValid(ValidationContext<T> context, int value)
    {
        return value > 0 && (value & value - 1) == 0;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.Number_PowerOfTwo;
}
