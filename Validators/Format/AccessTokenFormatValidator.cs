using System.Text.RegularExpressions;

using FluentValidation;
using FluentValidation.Validators;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;
public sealed class AccessTokenFormatValidator<T> : PropertyValidator<T, string>
{
    // header.payload.signature
    private static readonly Regex _jwtRegex = new(@"^[A-Za-z0-9-_]+\.[A-Za-z0-9-_]+\.[A-Za-z0-9-_]+$", RegexOptions.Compiled);

    public override string Name => nameof(AccessTokenFormatValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && _jwtRegex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.AccessToken_Invalid;
}
