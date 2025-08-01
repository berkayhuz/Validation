﻿using FluentValidation;


using Validation.Core.Messages;

namespace Validation.Core.Validators.Date;

public sealed class DateNotInFutureValidator<T> : BaseValidator<T, DateTime>
{
    public override string Name => nameof(DateNotInFutureValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, DateTime value)
    {
        return value <= System.DateTime.UtcNow;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        ValidationResource.Date_InFuture;
}
