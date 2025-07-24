using FluentValidation;


using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class HostnameValidator<T> : BaseValidator<T, string>
{
    // RFC 1035 uyumlu basit hostname regex'i (IDN desteklemez)
    private static readonly Regex _hostnameRegex = new(
        @"^(?=.{1,253}$)(?!-)[A-Za-z0-9-]{1,63}(?<!-)(\.(?!-)[A-Za-z0-9-]{1,63}(?<!-))*\.?$",
        RegexOptions.Compiled);

    public override string Name => nameof(HostnameValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && _hostnameRegex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.String_Hostname;
}
