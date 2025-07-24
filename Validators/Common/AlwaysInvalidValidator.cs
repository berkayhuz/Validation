using FluentValidation;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Common;

public sealed class AlwaysInvalidValidator<T> : BaseValidator<T, string>
{
    public override string Name => nameof(AlwaysInvalidValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value) => false;

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.Dev_AlwaysInvalid;
}
