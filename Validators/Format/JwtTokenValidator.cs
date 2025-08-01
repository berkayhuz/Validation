﻿using FluentValidation;


using System.Text.RegularExpressions;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Format;

public sealed class JwtTokenValidator<T> : BaseValidator<T, string>
{
    // Temel JWT formatı: 3 parçalı base64url (header.payload.signature)
    private static readonly Regex _jwtRegex = new(
        @"^[A-Za-z0-9-_]+\.[A-Za-z0-9-_]+\.[A-Za-z0-9-_]+$",
        RegexOptions.Compiled);

    public override string Name => nameof(JwtTokenValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, string value)
    {
        return !string.IsNullOrWhiteSpace(value) && _jwtRegex.IsMatch(value);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.String_JwtToken;
}
