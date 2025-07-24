using FluentValidation;
using FluentValidation.Validators;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Numeric;

public sealed class MultipleOfValidator<T> : PropertyValidator<T, int>
{
    private readonly int _divisor;

    public MultipleOfValidator(int divisor)
    {
        _divisor = divisor;
    }

    public override string Name => nameof(MultipleOfValidator<T>);

    public override bool IsValid(ValidationContext<T> context, int value)
    {
        return _divisor != 0 && value % _divisor == 0;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        string.Format(ValidationMessages.Number_MultipleOf, _divisor);
}
