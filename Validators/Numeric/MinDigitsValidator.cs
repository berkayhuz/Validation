using FluentValidation;


using Validation.Core.Messages;

namespace Validation.Core.Validators.Numeric;

public sealed class MinDigitsValidator<T> : BaseValidator<T, int>
{
    private readonly int _minDigits;

    public MinDigitsValidator(int minDigits)
    {
        _minDigits = minDigits;
    }

    public override string Name => nameof(MinDigitsValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, int value)
    {
        var digitCount = Math.Abs(value).ToString().Length;
        return digitCount >= _minDigits;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        string.Format(ValidationResource.Number_MinDigits, _minDigits);
}
