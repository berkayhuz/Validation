using FluentValidation;


using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class MimeTypeValidator<T> : BaseValidator<T, string>
{
    private static readonly Regex _mimeRegex = new(@"^[a-z]+\/[a-z0-9\-\.\+]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public override string Name => nameof(MimeTypeValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && _mimeRegex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.String_MimeType;
}
