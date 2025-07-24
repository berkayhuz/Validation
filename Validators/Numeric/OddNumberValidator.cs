using FluentValidation;


using Validation.Core.Messages;

namespace Validation.Core.Validators.Numeric;

public sealed class OddNumberValidator<T> : BaseValidator<T, int>
{
    public override string Name => nameof(OddNumberValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, int value)
    {
        return value % 2 != 0;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.Number_Odd;
}
