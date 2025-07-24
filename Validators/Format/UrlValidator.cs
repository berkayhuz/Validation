using FluentValidation;


using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;
public sealed class UrlValidator<T> : BaseValidator<T, string>
{
    public override string Name => nameof(UrlValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return false;

        return Uri.TryCreate(value, UriKind.Absolute, out var uri)
               && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.Url_Invalid;
}
