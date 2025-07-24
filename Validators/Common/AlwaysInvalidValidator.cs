using FluentValidation;
using FluentValidation.Validators;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Common;

public sealed class AlwaysInvalidValidator<T> : PropertyValidator<T, string>
{
    public override string Name => nameof(AlwaysInvalidValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value) => false;

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.Dev_AlwaysInvalid;
}
