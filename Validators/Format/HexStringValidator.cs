using FluentValidation;


using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class HexStringValidator<T> : BaseValidator<T, string>
{
    private static readonly Regex _hexRegex = new(@"^(#|0x)?[0-9A-Fa-f]+$", RegexOptions.Compiled);

    public override string Name => nameof(HexStringValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && _hexRegex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.Hex_Invalid;
}
