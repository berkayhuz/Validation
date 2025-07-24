using System.ComponentModel.DataAnnotations;

using FluentValidation;
using FluentValidation.Validators;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class EmailValidator<T> : PropertyValidator<T, string>
{
    private static readonly EmailAddressAttribute _attr = new();

    public override string Name => nameof(EmailValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value) =>
        !string.IsNullOrWhiteSpace(value) && _attr.IsValid(value);

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.Email_Invalid;    // aşağıdaki sabite/RESX'e bak
}
