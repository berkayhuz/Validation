using FluentValidation;
using FluentValidation.Validators;

using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Security;

public sealed class XssSafeStringValidator<T> : PropertyValidator<T, string>
{
    private static readonly Regex _xssRegex = new(@"<[^>]+>|(script|on\w+)\s*=", RegexOptions.IgnoreCase | RegexOptions.Compiled);

    public override string Name => nameof(XssSafeStringValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        return string.IsNullOrWhiteSpace(value) || !_xssRegex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.Security_XssSafe;
}
