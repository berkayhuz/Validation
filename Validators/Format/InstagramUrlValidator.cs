using FluentValidation;
using FluentValidation.Validators;

using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class InstagramUrlValidator<T> : PropertyValidator<T, string>
{
    private static readonly Regex _instagramRegex = new(
        @"^(https?:\/\/)?(www\.)?instagram\.com\/([a-zA-Z0-9_.]+)\/?$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public override string Name => nameof(InstagramUrlValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && _instagramRegex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.Url_Instagram;
}
