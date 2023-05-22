using AutoMapper;
using AutoMapper.QueryableExtensions;
using AudioStreaming.Application.Common.Interfaces;
using AudioStreaming.Application.Common.Mappings;
using AudioStreaming.Application.Common.Models;
using MediatR;

namespace AudioStreaming.Application.Albums.Queries.GetAlbumsWithPagination;

public record GetAlbumsWithPaginationQuery : IRequest<PaginatedList<AlbumDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetAlbumsWithPaginationQueryHandler : IRequestHandler<GetAlbumsWithPaginationQuery, PaginatedList<AlbumDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAlbumsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<AlbumDto>> Handle(GetAlbumsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Albums
            .OrderBy(x => x.Title)
            .ProjectTo<AlbumDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
