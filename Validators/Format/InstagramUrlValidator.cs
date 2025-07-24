using FluentValidation;


using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class InstagramUrlValidator<T> : BaseValidator<T, string>
{
    private static readonly Regex _instagramRegex = new(
        @"^(https?:\/\/)?(www\.)?instagram\.com\/([a-zA-Z0-9_.]+)\/?$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public override string Name => nameof(InstagramUrlValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && _instagramRegex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.Url_Instagram;
}
