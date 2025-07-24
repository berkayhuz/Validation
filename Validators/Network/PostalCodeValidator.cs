using System.Text.RegularExpressions;

using FluentValidation;


using Validation.Core.Messages;

namespace Validation.Core.Validators.Network;
public sealed class PostalCodeValidator<T> : BaseValidator<T, string>
{
    private static readonly Regex _postalCodeRegex = new(@"^\d{4,10}$", RegexOptions.Compiled);

    public override string Name => nameof(PostalCodeValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && _postalCodeRegex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.PostalCode_Invalid;
}
