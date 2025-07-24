using FluentValidation;
using FluentValidation.Validators;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Numeric;

public sealed class DivisibleByValidator<T> : PropertyValidator<T, int>
{
    private readonly int _divisor;

    public DivisibleByValidator(int divisor)
    {
        _divisor = divisor;
    }

    public override string Name => nameof(DivisibleByValidator<T>);

    public override bool IsValid(ValidationContext<T> context, int value)
    {
        return _divisor != 0 && value % _divisor == 0;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        string.Format(ValidationMessages.Number_DivisibleBy, _divisor);
}
