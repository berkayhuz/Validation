using FluentValidation;


using Validation.Core.Messages;

namespace Validation.Core.Validators.Numeric;

public sealed class PrimeNumberValidator<T> : BaseValidator<T, int>
{
    public override string Name => nameof(PrimeNumberValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, int value)
    {
        if (value <= 1)
            return false;
        if (value == 2)
            return true;
        if (value % 2 == 0)
            return false;

        var boundary = (int)Math.Floor(Math.Sqrt(value));
        for (var i = 3; i <= boundary; i += 2)
        {
            if (value % i == 0)
                return false;
        }

        return true;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.Number_Prime;
}
