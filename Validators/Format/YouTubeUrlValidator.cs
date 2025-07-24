using FluentValidation;


using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class YouTubeUrlValidator<T> : BaseValidator<T, string>
{
    // Hem normal hem short YouTube linklerini kapsar
    private static readonly Regex _youtubeRegex = new(
        @"^(https?:\/\/)?(www\.)?(youtube\.com\/watch\?v=|youtu\.be\/)[\w\-]{11}(&.*)?$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public override string Name => nameof(YouTubeUrlValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && _youtubeRegex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.Url_YouTube;
}
