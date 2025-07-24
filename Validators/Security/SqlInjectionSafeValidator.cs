using FluentValidation;
using FluentValidation.Validators;

using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Security;

public sealed class SqlInjectionSafeValidator<T> : PropertyValidator<T, string>
{
    private static readonly Regex _sqlRegex = new(@"('|--|;|/\*|\*/|xp_|exec|select\s|insert\s|delete\s|drop\s|union\s|or\s+1=1)", RegexOptions.IgnoreCase | RegexOptions.Compiled);

    public override string Name => nameof(SqlInjectionSafeValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        return string.IsNullOrWhiteSpace(value) || !_sqlRegex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.Security_SqlInjectionSafe;
}
