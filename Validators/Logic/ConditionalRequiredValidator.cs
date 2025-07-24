using FluentValidation;
using FluentValidation.Validators;

using System.Reflection;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Logic;

public sealed class ConditionalRequiredValidator<T> : PropertyValidator<T, string>
{
    private readonly string _dependentPropertyName;
    private readonly string? _requiredWhenValue;

    public ConditionalRequiredValidator(string dependentPropertyName, string? requiredWhenValue = null)
    {
        _dependentPropertyName = dependentPropertyName;
        _requiredWhenValue = requiredWhenValue;
    }

    public override string Name => nameof(ConditionalRequiredValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        var instance = context.InstanceToValidate;
        var dependentProp = typeof(T).GetProperty(_dependentPropertyName, BindingFlags.Public | BindingFlags.Instance);

        if (dependentProp == null)
            return true;

        var dependentValue = dependentProp.GetValue(instance)?.ToString();

        var shouldBeRequired = _requiredWhenValue == null || dependentValue == _requiredWhenValue;
        if (!shouldBeRequired)
            return true;

        return !string.IsNullOrWhiteSpace(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode)
    {
        return _requiredWhenValue is null
            ? string.Format(ValidationMessages.Logic_ConditionalRequired, _dependentPropertyName)
            : string.Format(ValidationMessages.Logic_ConditionalRequiredWithValue, _dependentPropertyName, _requiredWhenValue);
    }
}
