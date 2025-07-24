using FluentValidation;
using FluentValidation.Validators;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Date;

public sealed class TimeRangeValidator<T> : PropertyValidator<T, TimeOnly>
{
    private readonly TimeOnly _start;
    private readonly TimeOnly _end;

    public TimeRangeValidator(TimeOnly start, TimeOnly end)
    {
        _start = start;
        _end = end;
    }

    public override string Name => nameof(TimeRangeValidator<T>);

    public override bool IsValid(ValidationContext<T> context, TimeOnly value)
    {
        return value >= _start && value <= _end;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        string.Format(ValidationMessages.Time_Range, _start.ToString("HH\\:mm"), _end.ToString("HH\\:mm"));
}
