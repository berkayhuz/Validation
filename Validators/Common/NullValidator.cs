using FluentValidation;
using FluentValidation.Validators;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Common;
public sealed class NullValidator<T, TProperty> : PropertyValidator<T, TProperty>
{
    public override string Name => nameof(NullValidator<T, TProperty>);

    public override bool IsValid(ValidationContext<T> context, TProperty value)
        => value is null;

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.MustBeNull;
}
