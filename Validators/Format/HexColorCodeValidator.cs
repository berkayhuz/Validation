using FluentValidation;
using FluentValidation.Validators;

using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class HexColorCodeValidator<T> : PropertyValidator<T, string>
{
    private static readonly Regex _hexColorRegex = new(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$", RegexOptions.Compiled);

    public override string Name => nameof(HexColorCodeValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && _hexColorRegex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.String_HexColor;
}
