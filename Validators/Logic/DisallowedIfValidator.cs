using FluentValidation;
using FluentValidation.Validators;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Logic;

public sealed class DisallowedIfValidator<T, TProperty> : PropertyValidator<T, TProperty>
{
    private readonly Func<T, bool> _condition;

    public DisallowedIfValidator(Func<T, bool> condition)
    {
        _condition = condition;
    }

    public override string Name => nameof(DisallowedIfValidator<T, TProperty>);

    public override bool IsValid(ValidationContext<T> context, TProperty value)
    {
        if (_condition(context.InstanceToValidate))
            return value is null || string.IsNullOrWhiteSpace(value?.ToString());

        return true;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.Logic_DisallowedIf;
}
