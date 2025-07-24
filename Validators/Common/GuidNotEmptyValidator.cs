using FluentValidation;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Common;
public sealed class GuidNotEmptyValidator<T> : BaseValidator<T, Guid>
{
    public override string Name => nameof(GuidNotEmptyValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, Guid value)
        => value != Guid.Empty;

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.Guid_Empty;
}

