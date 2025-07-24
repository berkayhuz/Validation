using FluentValidation;
using FluentValidation.Validators;

using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class HexStringValidator<T> : PropertyValidator<T, string>
{
    private static readonly Regex _hexRegex = new(@"^(#|0x)?[0-9A-Fa-f]+$", RegexOptions.Compiled);

    public override string Name => nameof(HexStringValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && _hexRegex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.Hex_Invalid;
}
