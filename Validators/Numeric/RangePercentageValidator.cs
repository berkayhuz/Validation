using FluentValidation;


using Validation.Core.Messages;

namespace Validation.Core.Validators.Numeric;

public sealed class RangePercentageValidator<T> : BaseValidator<T, decimal>
{
    public override string Name => nameof(RangePercentageValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, decimal value)
    {
        return value >= 0 && value <= 100;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.Number_PercentageRange;
}
