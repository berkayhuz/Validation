using FluentValidation;


using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class ContainsSpecialCharactersValidator<T> : BaseValidator<T, string>
{
    private static readonly Regex _specialCharRegex = new(@"[\W_]", RegexOptions.Compiled);
    // \W = non-word character (includes !@#$ etc), _ dahil

    public override string Name => nameof(ContainsSpecialCharactersValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && _specialCharRegex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.String_SpecialCharRequired;
}
