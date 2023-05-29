using FluentValidation;

namespace AudioStreaming.Application.Albums.Queries.GetAlbumsWithPagination;

public class GetAlbumsWithPaginationQueryValidator : AbstractValidator<GetAlbumsWithPaginationQuery>
{
    public GetAlbumsWithPaginationQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}