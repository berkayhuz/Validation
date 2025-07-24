using FluentValidation;

using FluentValidation.Results;
using FluentValidation.Validators;

namespace Validation.Core.Validators;

public abstract class BaseValidator<T, TProperty> : PropertyValidator<T, TProperty>
{
    public override string Name => GetType().Name;

    public override bool IsValid(ValidationContext<T> context, TProperty value)
    {
        if (IsValidInternal(context, value))
            return true;

        context.AddFailure(new ValidationFailure(context.PropertyPath, GetDefaultMessageTemplate("Custom"))
        {
            CustomState = Name
        });

        return false;
    }

    protected abstract bool IsValidInternal(ValidationContext<T> context, TProperty value);

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        "Validation error occurred.";
}
