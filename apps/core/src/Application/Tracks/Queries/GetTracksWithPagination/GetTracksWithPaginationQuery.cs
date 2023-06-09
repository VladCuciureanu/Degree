using AudioStreaming.Application.Common.Interfaces;
using AudioStreaming.Application.Common.Mappings;
using AudioStreaming.Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;

namespace AudioStreaming.Application.Tracks.Queries.GetTracksWithPagination;

public record GetTracksWithPaginationQuery : IRequest<PaginatedList<TrackDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetTracksWithPaginationQueryHandler : IRequestHandler<GetTracksWithPaginationQuery, PaginatedList<TrackDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTracksWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<TrackDto>> Handle(GetTracksWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Tracks
            .OrderBy(x => x.Name)
            .ProjectTo<TrackDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}