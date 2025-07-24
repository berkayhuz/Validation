using FluentValidation;
using FluentValidation.Validators;

using System.Text.Json;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class JsonStringValidator<T> : PropertyValidator<T, string>
{
    public override string Name => nameof(JsonStringValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
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
        ValidationMessages.Json_Invalid;
}
