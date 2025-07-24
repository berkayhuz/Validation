using FluentValidation;


using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class VersionStringValidator<T> : BaseValidator<T, string>
{
    // SemVer: 1.0.0, 2.1.3-beta, v3.2.1+build42, vs.
    private static readonly Regex _semverRegex = new(
        @"^(v)?(0|[1-9]\d*)\.(0|[1-9]\d*)\.(0|[1-9]\d*)(?:-[\da-z\-]+(?:\.[\da-z\-]+)*)?(?:\+[\da-z\-]+(?:\.[\da-z\-]+)*)?$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public override string Name => nameof(VersionStringValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && _semverRegex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.String_Version;
}
