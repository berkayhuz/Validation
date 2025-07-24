using FluentValidation;


using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Security;

public sealed class SqlInjectionSafeValidator<T> : BaseValidator<T, string>
{
    private static readonly Regex _sqlRegex = new(@"('|--|;|/\*|\*/|xp_|exec|select\s|insert\s|delete\s|drop\s|union\s|or\s+1=1)", RegexOptions.IgnoreCase | RegexOptions.Compiled);

    public override string Name => nameof(SqlInjectionSafeValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value)
    {
        return string.IsNullOrWhiteSpace(value) || !_sqlRegex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.Security_SqlInjectionSafe;
}
