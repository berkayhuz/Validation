using FluentValidation;
using FluentValidation.Validators;

using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Network;

public sealed class HostnameWithPortValidator<T> : PropertyValidator<T, string>
{
    // Hostname + colon + port (1-5 digit)
    private static readonly Regex _hostPortRegex =
        new(@"^([a-zA-Z0-9\-\.]+):([0-9]{1,5})$", RegexOptions.Compiled);

    public override string Name => nameof(HostnameWithPortValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return false;

        var match = _hostPortRegex.Match(value);
        if (!match.Success)
            return false;

        // Optional: validate port range
        if (int.TryParse(match.Groups[2].Value, out var port))
            return port > 0 && port <= 65535;

        return false;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.Network_HostnameWithPort;
}
