using FluentValidation;


using Validation.Core.Messages;

namespace Validation.Core.Validators.Date;

public sealed class TimeRangeValidator<T> : BaseValidator<T, TimeOnly>
{
    private readonly TimeOnly _start;
    private readonly TimeOnly _end;

    public TimeRangeValidator(TimeOnly start, TimeOnly end)
    {
        _start = start;
        _end = end;
    }

    public override string Name => nameof(TimeRangeValidator<T>);

    protected override bool IsValidInternal(ValidationContext<T> context, TimeOnly value)
    {
        return value >= _start && value <= _end;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) =>
        string.Format(ValidationResource.Time_Range, _start.ToString("HH\\:mm"), _end.ToString("HH\\:mm"));
}
