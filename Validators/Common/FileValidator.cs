using FluentValidation;

using Microsoft.AspNetCore.Http;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Common;

public sealed class FileValidator<T> : BaseValidator<T, IFormFile>
{
    private readonly long _maxSizeInBytes;
    private readonly string[] _allowedExtensions;
    private readonly string[] _allowedContentTypes;

    public FileValidator(
        long maxSizeInBytes,
        string[]? allowedExtensions = null,
        string[]? allowedContentTypes = null)
    {
        _maxSizeInBytes = maxSizeInBytes;
        _allowedExtensions = allowedExtensions ?? [];
        _allowedContentTypes = allowedContentTypes ?? [];
    }

    public override string Name => nameof(FileValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, IFormFile value)
    {
        if (value is null)
            return true;

        if (value.Length > _maxSizeInBytes)
            return false;

        if (_allowedExtensions.Any() &&
            !_allowedExtensions.Contains(Path.GetExtension(value.FileName).ToLower()))
            return false;

        if (_allowedContentTypes.Any() &&
            !_allowedContentTypes.Contains(value.ContentType))
            return false;

        return true;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.File_Invalid;
}
