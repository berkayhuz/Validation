using FluentValidation;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Date;
//Farklı kullanımı var builderde yok. direkt validator içinde aşşadaki gibi örneğin.
//public record BookingDto(DateTime StartDate, DateTime EndDate) : IHasDateRange;

//public class BookingDtoValidator : AbstractValidator<BookingDto>
//{
//    public BookingDtoValidator()
//    {
//        RuleFor(x => x).SetValidator(new DateRangeValidator<BookingDto>());
//    }
//}
public interface IHasDateRange
{
    DateTime StartDate
    {
        get;
    }
    DateTime EndDate
    {
        get;
    }
}

public sealed class DateRangeValidator<T> : AbstractValidator<T> where T : IHasDateRange
{
    public DateRangeValidator()
    {
        RuleFor(x => x.StartDate)
            .LessThanOrEqualTo(x => x.EndDate)
            .WithMessage(ValidationResource.DateRange_StartAfterEnd);
    }
}
