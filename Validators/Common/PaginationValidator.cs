using FluentValidation;

using Validation.Core.Messages;

namespace Validation.Core.Validators.Common;
public interface IPagination
{
    int PageNumber
    {
        get;
    }
    int PageSize
    {
        get;
    }
}

public sealed class PaginationValidator<T> : AbstractValidator<T> where T : IPagination
{
    public PaginationValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1)
            .WithMessage(ValidationMessages.Pagination_PageNumber);

        RuleFor(x => x.PageSize)
            .InclusiveBetween(1, 100)
            .WithMessage(ValidationMessages.Pagination_PageSize);
    }
}
