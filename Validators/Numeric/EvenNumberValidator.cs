using FluentValidation;
using FluentValidation.Validators;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Numeric;

public sealed class EvenNumberValidator<T> : PropertyValidator<T, int>
{
    public override string Name => nameof(EvenNumberValidator<T>);

    public override bool IsValid(ValidationContext<T> context, int value)
    {
        return value % 2 == 0;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.Number_Even;
}
