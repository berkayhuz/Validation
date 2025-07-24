using FluentValidation;
using FluentValidation.Validators;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Common;
public sealed class GuidNotEmptyValidator<T> : PropertyValidator<T, Guid>
{
    public override string Name => nameof(GuidNotEmptyValidator<T>);

    public override bool IsValid(ValidationContext<T> context, Guid value) =>
        value != Guid.Empty;

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.Guid_Empty;
}
