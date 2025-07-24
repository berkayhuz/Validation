using System.Net;

using FluentValidation;
using FluentValidation.Validators;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Network;
public sealed class IpAddressValidator<T> : PropertyValidator<T, string>
{
    public override string Name => nameof(IpAddressValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && IPAddress.TryParse(value, out _);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.IpAddress_Invalid;
}
