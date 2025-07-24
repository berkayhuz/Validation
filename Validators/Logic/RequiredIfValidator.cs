using FluentValidation;
using FluentValidation.Validators;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Logic;

public sealed class RequiredIfValidator<T, TProperty> : PropertyValidator<T, TProperty>
{
    private readonly Func<T, bool> _condition;

    public RequiredIfValidator(Func<T, bool> condition)
    {
        _condition = condition;
    }

    public override string Name => nameof(RequiredIfValidator<T, TProperty>);

    public override bool IsValid(ValidationContext<T> context, TProperty value)
    {
        if (_condition(context.InstanceToValidate))
            return value is not null && !string.IsNullOrWhiteSpace(value?.ToString());

        return true;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.Logic_RequiredIf;
}
