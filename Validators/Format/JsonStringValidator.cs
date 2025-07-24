using FluentValidation;


using System.Text.Json;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class JsonStringValidator<T> : BaseValidator<T, string>
{
    public override string Name => nameof(JsonStringValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return false;

        try
        {
            JsonDocument.Parse(value);
            return true;
        }
        catch
        {
            return false;
        }
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.Json_Invalid;
}
