using FluentValidation;


using Validation.Core.Messages;

namespace Validation.Core.Validators.Common;
public sealed class NullValidator<T, TProperty> : BaseValidator<T, TProperty>
{
    public override string Name => nameof(NullValidator<T, TProperty>);

    protected override bool IsValidInternal(ValidationContext<T> context, TProperty value)
        => value is null;

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.MustBeNull;
}
