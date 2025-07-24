using FluentValidation;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Common;
public sealed class EnumValueValidator<T, TEnum> : BaseValidator<T, TEnum>
    where TEnum : struct, Enum
{
    public override string Name => nameof(EnumValueValidator<T, TEnum>);

    protected override bool IsValidInternal(ValidationContext<T> context, TEnum value)
    {
        return Enum.IsDefined(typeof(TEnum), value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.Enum_Invalid;
}
