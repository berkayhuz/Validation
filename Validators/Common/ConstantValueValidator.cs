using FluentValidation;
using FluentValidation.Validators;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Common;
public sealed class ConstantValueValidator<T, TValue> : PropertyValidator<T, TValue>
{
    private readonly TValue _expected;

    public ConstantValueValidator(TValue expected)
    {
        _expected = expected;
    }

    public override string Name => nameof(ConstantValueValidator<T, TValue>);

    public override bool IsValid(ValidationContext<T> context, TValue value)
    {
        return Equals(value, _expected);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        string.Format(ValidationMessages.ConstantValue, _expected);
}
