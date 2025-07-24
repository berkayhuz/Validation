using FluentValidation;


using System.Globalization;
using System.Text;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Security;

public sealed class NoUnicodeSymbolsValidator<T> : BaseValidator<T, string>
{
    public override string Name => nameof(NoUnicodeSymbolsValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return true;

        foreach (var rune in value.EnumerateRunes())
        {
            var category = Rune.GetUnicodeCategory(rune);
            if (category is UnicodeCategory.OtherSymbol or UnicodeCategory.Surrogate or UnicodeCategory.Control)
                return false;
        }

        return true;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.Security_NoUnicodeSymbols;
}
