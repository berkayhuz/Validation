using FluentValidation;


using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Security;

public sealed class EncryptedStringValidator<T> : BaseValidator<T, string>
{
    // Base64 URL-safe (AES/RSA vb. şifreleme sonrası tipik çıktı)
    private static readonly Regex _base64Regex = new(@"^[A-Za-z0-9\-_+=\/]{16,}$", RegexOptions.Compiled);

    public override string Name => nameof(EncryptedStringValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && _base64Regex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.Security_Encrypted;
}
