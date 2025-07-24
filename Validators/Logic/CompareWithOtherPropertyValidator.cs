using FluentValidation;


using Validation.Core.Messages;

namespace Validation.Core.Validators.Logic;

public sealed class CompareWithOtherPropertyValidator<T> : BaseValidator<T, IComparable>
{
    private readonly Func<T, IComparable> _otherSelector;
    private readonly Func<IComparable, IComparable, bool> _comparer;

    public CompareWithOtherPropertyValidator(
        Func<T, IComparable> otherSelector,
        Func<IComparable, IComparable, bool> comparer)
    {
        _otherSelector = otherSelector;
        _comparer = comparer;
    }

    public override string Name => nameof(CompareWithOtherPropertyValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, IComparable value)
    {
        var other = _otherSelector(context.InstanceToValidate);
        return value != null && other != null && _comparer(value, other);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.Logic_CompareWithOther;
}
