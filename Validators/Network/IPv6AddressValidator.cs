using System.Net;

using FluentValidation;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Network;

public sealed class IPv6AddressValidator<T> : BaseValidator<T, string>
{
    public override string Name => nameof(IPv6AddressValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value)
    {
        return IPAddress.TryParse(value, out var ip) && ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.Network_IPv6Address;
}
