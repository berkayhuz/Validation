using FluentValidation;
using FluentValidation.Validators;

using System.Net;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Network;

public sealed class IPv6AddressValidator<T> : PropertyValidator<T, string>
{
    public override string Name => nameof(IPv6AddressValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        return IPAddress.TryParse(value, out var ip) && ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.Network_IPv6Address;
}
