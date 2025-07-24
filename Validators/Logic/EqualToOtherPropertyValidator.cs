using FluentValidation;
using FluentValidation.Validators;

using System.Reflection;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Logic;

public sealed class EqualToOtherPropertyValidator<T> : PropertyValidator<T, string>
{
    private readonly string _otherPropertyName;

    public EqualToOtherPropertyValidator(string otherPropertyName)
    {
        _otherPropertyName = otherPropertyName;
    }

    public override string Name => nameof(EqualToOtherPropertyValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        var instance = context.InstanceToValidate;
        var otherProperty = typeof(T).GetProperty(_otherPropertyName, BindingFlags.Public | BindingFlags.Instance);
        if (otherProperty == null)
            return false;

        var otherValue = otherProperty.GetValue(instance)?.ToString();
        return value == otherValue;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        string.Format(ValidationMessages.Logic_EqualToOtherProperty, _otherPropertyName);
}
