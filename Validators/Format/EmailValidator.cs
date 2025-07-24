using System.ComponentModel.DataAnnotations;

using FluentValidation;


using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class EmailValidator<T> : BaseValidator<T, string>
{
    private static readonly EmailAddressAttribute _attr = new();

    public override string Name => nameof(EmailValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value) =>
        !string.IsNullOrWhiteSpace(value) && _attr.IsValid(value);

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.Email_Invalid;    // aşağıdaki sabite/RESX'e bak
}
