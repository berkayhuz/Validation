using FluentValidation;
using FluentValidation.Validators;

using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Security;

public sealed class PasswordHasSymbolValidator<T> : PropertyValidator<T, string>
{
    // Harf ve rakam dışında herhangi bir karakter
    private static readonly Regex _symbolRegex = new(@"[^\w\s]", RegexOptions.Compiled);

    public override string Name => nameof(PasswordHasSymbolValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && _symbolRegex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.Password_SymbolRequired;
}
