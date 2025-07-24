using FluentValidation;
using FluentValidation.Validators;

using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class HostnameValidator<T> : PropertyValidator<T, string>
{
    // RFC 1035 uyumlu basit hostname regex'i (IDN desteklemez)
    private static readonly Regex _hostnameRegex = new(
        @"^(?=.{1,253}$)(?!-)[A-Za-z0-9-]{1,63}(?<!-)(\.(?!-)[A-Za-z0-9-]{1,63}(?<!-))*\.?$",
        RegexOptions.Compiled);

    public override string Name => nameof(HostnameValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && _hostnameRegex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.String_Hostname;
}
