using FluentValidation;


using System.Reflection;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Logic;

public sealed class MutuallyExclusivePropertiesValidator<T> : BaseValidator<T, T>
{
    private readonly string[] _propertyNames;

    public MutuallyExclusivePropertiesValidator(params string[] propertyNames)
    {
        _propertyNames = propertyNames;
    }

    public override string Name => nameof(MutuallyExclusivePropertiesValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, T value)
    {
        if (_propertyNames.Length < 2)
            return true;

        var filledCount = _propertyNames
            .Select(p => typeof(T).GetProperty(p, BindingFlags.Public | BindingFlags.Instance))
            .Where(prop => prop is not null)
            .Select(prop => prop!.GetValue(context.InstanceToValidate))
            .Count(val => val is string s ? !string.IsNullOrWhiteSpace(s) : val is not null);

        return filledCount == 1;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        string.Format(ValidationResource.Logic_MutuallyExclusiveProperties, string.Join(", ", _propertyNames));
}
