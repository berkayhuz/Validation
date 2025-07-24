using FluentValidation;


using Validation.Core.Messages;

namespace Validation.Core.Validators.Common;

public sealed class NotNullOverrideValidator<T, TProperty> : BaseValidator<T, TProperty>
{
    public override string Name => nameof(NotNullOverrideValidator<T, TProperty>);

    protected override bool IsValidInternal(ValidationContext<T> context, TProperty value)
        => value is not null;

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.MustNotBeNull;
}
