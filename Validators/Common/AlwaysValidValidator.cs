using FluentValidation;
using FluentValidation.Validators;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Common;

public sealed class AlwaysValidValidator<T> : PropertyValidator<T, string>
{
    public override string Name => nameof(AlwaysValidValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value) => true;

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.Dev_AlwaysValid;
}
