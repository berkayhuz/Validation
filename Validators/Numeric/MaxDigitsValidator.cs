using FluentValidation;


using Validation.Core.Messages;

namespace Validation.Core.Validators.Numeric;

public sealed class MaxDigitsValidator<T> : BaseValidator<T, int>
{
    private readonly int _maxDigits;

    public MaxDigitsValidator(int maxDigits)
    {
        _maxDigits = maxDigits;
    }

    public override string Name => nameof(MaxDigitsValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, int value)
    {
        var digitCount = Math.Abs(value).ToString().Length;
        return digitCount <= _maxDigits;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        string.Format(ValidationResource.Number_MaxDigits, _maxDigits);
}
