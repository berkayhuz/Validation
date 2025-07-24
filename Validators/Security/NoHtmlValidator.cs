using FluentValidation;


using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Security;

public sealed class NoHtmlValidator<T> : BaseValidator<T, string>
{
    private static readonly Regex _htmlTagRegex = new(@"<[^>]+>", RegexOptions.Compiled);

    public override string Name => nameof(NoHtmlValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value)
    {
        return string.IsNullOrWhiteSpace(value) || !_htmlTagRegex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.Security_NoHtml;
}
