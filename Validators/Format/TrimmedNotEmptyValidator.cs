using FluentValidation;


using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;
public sealed class TrimmedNotEmptyValidator<T> : BaseValidator<T, string>
{
    public override string Name => nameof(TrimmedNotEmptyValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.String_TrimmedEmpty;
}
