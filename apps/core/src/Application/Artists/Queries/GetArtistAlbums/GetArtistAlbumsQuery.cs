using AudioStreaming.Application.Albums.Queries;
using AudioStreaming.Application.Common.Interfaces;
using AudioStreaming.Application.Common.Mappings;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AudioStreaming.Application.Tracks.Queries.GetArtistAlbums;

public record GetArtistAlbumsQuery : IRequest<List<AlbumDto>>
{
    public GetArtistAlbumsQuery(int id)
    {
        Id = id;
    }

    public int Id { get; init; } = default!;
}

public class GetArtistAlbumsQueryHandler : IRequestHandler<GetArtistAlbumsQuery, List<AlbumDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetArtistAlbumsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<AlbumDto>> Handle(GetArtistAlbumsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Albums
            .Where(a => a.ArtistId == request.Id)
            .ProjectTo<AlbumDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }
}