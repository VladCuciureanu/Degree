using FluentValidation;

namespace AudioStreaming.Application.Tracks.Queries.GetTracksWithPagination;

public class GetTracksWithPaginationQueryValidator : AbstractValidator<GetTracksWithPaginationQuery>
{
    public GetTracksWithPaginationQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}
