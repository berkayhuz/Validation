using FluentValidation;
using FluentValidation.Validators;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Common;

public sealed class NotNullOverrideValidator<T, TProperty> : PropertyValidator<T, TProperty>
{
    public override string Name => nameof(NotNullOverrideValidator<T, TProperty>);

    public override bool IsValid(ValidationContext<T> context, TProperty value)
        => value is not null;

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.MustNotBeNull;
}
