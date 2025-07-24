using FluentValidation;


using Validation.Core.Messages;

namespace Validation.Core.Validators.Numeric;

public sealed class DecimalPrecisionValidator<T> : BaseValidator<T, decimal>
{
    private readonly int _maxPrecision;
    private readonly int _maxScale;

    public DecimalPrecisionValidator(int maxPrecision, int maxScale)
    {
        _maxPrecision = maxPrecision;
        _maxScale = maxScale;
    }

    public override string Name => nameof(DecimalPrecisionValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, decimal value)
    {
        var parts = value.ToString(System.Globalization.CultureInfo.InvariantCulture).Split('.');

        var integerLength = parts[0].TrimStart('-').Length;
        var fractionalLength = parts.Length > 1 ? parts[1].Length : 0;
        var totalLength = integerLength + fractionalLength;

        return totalLength <= _maxPrecision && fractionalLength <= _maxScale;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.Decimal_PrecisionExceeded;
}
