using FluentValidation;
using FluentValidation.Validators;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Numeric;

public sealed class MaxDigitsValidator<T> : PropertyValidator<T, int>
{
    private readonly int _maxDigits;

    public MaxDigitsValidator(int maxDigits)
    {
        _maxDigits = maxDigits;
    }

    public override string Name => nameof(MaxDigitsValidator<T>);

    public override bool IsValid(ValidationContext<T> context, int value)
    {
        var digitCount = Math.Abs(value).ToString().Length;
        return digitCount <= _maxDigits;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        string.Format(ValidationMessages.Number_MaxDigits, _maxDigits);
}
