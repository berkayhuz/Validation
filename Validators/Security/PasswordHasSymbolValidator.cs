using FluentValidation;


using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Security;

public sealed class PasswordHasSymbolValidator<T> : BaseValidator<T, string>
{
    // Harf ve rakam dışında herhangi bir karakter
    private static readonly Regex _symbolRegex = new(@"[^\w\s]", RegexOptions.Compiled);

    public override string Name => nameof(PasswordHasSymbolValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && _symbolRegex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.Password_SymbolRequired;
}
