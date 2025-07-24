using FluentValidation;
using FluentValidation.Validators;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Numeric;

public sealed class RangePercentageValidator<T> : PropertyValidator<T, decimal>
{
    public override string Name => nameof(RangePercentageValidator<T>);

    public override bool IsValid(ValidationContext<T> context, decimal value)
    {
        return value >= 0 && value <= 100;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.Number_PercentageRange;
}
