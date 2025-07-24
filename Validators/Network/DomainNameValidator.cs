using FluentValidation;
using FluentValidation.Validators;

using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Network;

public sealed class DomainNameValidator<T> : PropertyValidator<T, string>
{
    private static readonly Regex _domainRegex =
        new(@"^(?!\-)(?:[a-zA-Z0-9\-]{1,63}\.)+[a-zA-Z]{2,63}$", RegexOptions.Compiled);

    public override string Name => nameof(DomainNameValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && _domainRegex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.Network_DomainName;
}
