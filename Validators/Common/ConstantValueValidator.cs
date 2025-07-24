using FluentValidation;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Common;
public sealed class ConstantValueValidator<T, TValue> : BaseValidator<T, TValue>
{
    private readonly TValue _expected;

    public ConstantValueValidator(TValue expected)
    {
        _expected = expected;
    }

    public override string Name => nameof(ConstantValueValidator<T, TValue>);

    protected override bool IsValidInternal(ValidationContext<T> context, TValue value)
    {
        return Equals(value, _expected);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        string.Format(ValidationResource.ConstantValue, _expected);
}
