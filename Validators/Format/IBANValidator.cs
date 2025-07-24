using FluentValidation;


using System.Numerics;
using System.Text;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class IBANValidator<T> : BaseValidator<T, string>
{
    public override string Name => nameof(IBANValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return false;

        var iban = value.Replace(" ", "").ToUpper();

        if (iban.Length < 15 || iban.Length > 34)
            return false;

        // Move first 4 chars to end
        iban = iban[4..] + iban[..4];

        // Convert letters to numbers (A=10, B=11, ..., Z=35)
        var numericIban = new StringBuilder();
        foreach (var c in iban)
        {
            if (char.IsDigit(c))
                numericIban.Append(c);
            else if (char.IsLetter(c))
                numericIban.Append((c - 'A' + 10).ToString());
            else
                return false;
        }

        if (!BigInteger.TryParse(numericIban.ToString(), out var ibanNumber))
            return false;

        return ibanNumber % 97 == 1;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.IBAN_Invalid;
}
