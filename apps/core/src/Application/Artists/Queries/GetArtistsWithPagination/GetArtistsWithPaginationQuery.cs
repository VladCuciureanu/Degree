using AutoMapper;
using AutoMapper.QueryableExtensions;
using AudioStreaming.Application.Common.Interfaces;
using AudioStreaming.Application.Common.Mappings;
using AudioStreaming.Application.Common.Models;
using MediatR;

namespace AudioStreaming.Application.Artists.Queries.GetArtistsWithPagination;

public record GetArtistsWithPaginationQuery : IRequest<PaginatedList<ArtistDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetArtistsWithPaginationQueryHandler : IRequestHandler<GetArtistsWithPaginationQuery, PaginatedList<ArtistDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetArtistsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ArtistDto>> Handle(GetArtistsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Artists
            .OrderBy(x => x.Name)
            .ProjectTo<ArtistDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
