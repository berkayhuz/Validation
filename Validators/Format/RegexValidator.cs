using FluentValidation;
using FluentValidation.Validators;

using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class RegexValidator<T> : PropertyValidator<T, string>
{
    private readonly Regex _regex;

    public RegexValidator(string pattern, RegexOptions options = RegexOptions.None)
    {
        _regex = new Regex(pattern, options | RegexOptions.Compiled);
    }

    public override string Name => nameof(RegexValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && _regex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.Regex_Invalid;
}
