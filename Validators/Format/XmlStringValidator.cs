using FluentValidation;


using System.Xml;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class XmlStringValidator<T> : BaseValidator<T, string>
{
    public override string Name => nameof(XmlStringValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value)
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
        ValidationResource.Xml_Invalid;
}
