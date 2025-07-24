using FluentValidation;


using Validation.Core.Messages;

namespace Validation.Core.Validators.Common;

public sealed class AlwaysValidValidator<T> : BaseValidator<T, string>
{
    public override string Name => nameof(AlwaysValidValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value) => true;

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.Dev_AlwaysValid;
}
