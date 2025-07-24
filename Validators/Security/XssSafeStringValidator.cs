using FluentValidation;


using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Security;

public sealed class XssSafeStringValidator<T> : BaseValidator<T, string>
{
    private static readonly Regex _xssRegex = new(@"<[^>]+>|(script|on\w+)\s*=", RegexOptions.IgnoreCase | RegexOptions.Compiled);

    public override string Name => nameof(XssSafeStringValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value)
    {
        return string.IsNullOrWhiteSpace(value) || !_xssRegex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.Security_XssSafe;
}
