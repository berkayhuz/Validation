using System.Net;

using FluentValidation;


using Validation.Core.Messages;

namespace Validation.Core.Validators.Network;
public sealed class IpAddressValidator<T> : BaseValidator<T, string>
{
    public override string Name => nameof(IpAddressValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && IPAddress.TryParse(value, out _);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.IpAddress_Invalid;
}
