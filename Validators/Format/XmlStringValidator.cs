using FluentValidation;
using FluentValidation.Validators;

using System.Xml;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class XmlStringValidator<T> : PropertyValidator<T, string>
{
    public override string Name => nameof(XmlStringValidator<T>);

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return false;

        try
        {
            var doc = new XmlDocument();
            doc.LoadXml(value);
            return true;
        }
        catch
        {
            return false;
        }
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationMessages.Xml_Invalid;
}
