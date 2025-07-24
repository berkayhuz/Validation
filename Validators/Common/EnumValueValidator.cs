using FluentValidation;
using FluentValidation.Validators;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Common;
public sealed class EnumValueValidator<T, TEnum> : PropertyValidator<T, TEnum>
    where TEnum : struct, Enum
{
    public override string Name => nameof(EnumValueValidator<T, TEnum>);

    public override bool IsValid(ValidationContext<T> context, TEnum value)
    {
        return Enum.IsDefined(typeof(TEnum), value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.Enum_Invalid;
}
