using FluentValidation;


using Validation.Core.Messages;

namespace Validation.Core.Validators.Logic;

public sealed class RequiredIfValidator<T, TProperty> : BaseValidator<T, TProperty>
{
    private readonly Func<T, bool> _condition;

    public RequiredIfValidator(Func<T, bool> condition)
    {
        _condition = condition;
    }

    public override string Name => nameof(RequiredIfValidator<T, TProperty>);

    protected override bool IsValidInternal(ValidationContext<T> context, TProperty value)
    {
        if (_condition(context.InstanceToValidate))
            return value is not null && !string.IsNullOrWhiteSpace(value?.ToString());

        return true;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.Logic_RequiredIf;
}
