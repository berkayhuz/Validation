using FluentValidation;
using FluentValidation.Validators;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class NationalIdValidator<T> : PropertyValidator<T, string>
{
    public override string Name => nameof(NationalIdValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length != 11 || !value.All(char.IsDigit))
            return false;

        var digits = value.Select(c => c - '0').ToArray();

        if (digits[0] == 0)
            return false;

        var sumOdd = digits[0] + digits[2] + digits[4] + digits[6] + digits[8];
        var sumEven = digits[1] + digits[3] + digits[5] + digits[7];

        var digit10 = (sumOdd * 7 - sumEven) % 10;
        var digit11 = digits.Take(10).Sum() % 10;

        return digits[9] == digit10 && digits[10] == digit11;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.NationalId_Invalid;
}
