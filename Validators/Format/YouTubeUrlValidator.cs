using FluentValidation;
using FluentValidation.Validators;

using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class YouTubeUrlValidator<T> : PropertyValidator<T, string>
{
    // Hem normal hem short YouTube linklerini kapsar
    private static readonly Regex _youtubeRegex = new(
        @"^(https?:\/\/)?(www\.)?(youtube\.com\/watch\?v=|youtu\.be\/)[\w\-]{11}(&.*)?$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public override string Name => nameof(YouTubeUrlValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && _youtubeRegex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.Url_YouTube;
}
