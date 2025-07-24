using FluentValidation;
using FluentValidation.Validators;

using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class MimeTypeValidator<T> : PropertyValidator<T, string>
{
    private static readonly Regex _mimeRegex = new(@"^[a-z]+\/[a-z0-9\-\.\+]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public override string Name => nameof(MimeTypeValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && _mimeRegex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.String_MimeType;
}
