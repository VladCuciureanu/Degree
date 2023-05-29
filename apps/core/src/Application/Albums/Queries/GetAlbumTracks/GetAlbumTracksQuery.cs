using AudioStreaming.Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AudioStreaming.Application.Tracks.Queries.GetAlbumTracks;

public record GetAlbumTracksQuery : IRequest<List<TrackDto>>
{
    public GetAlbumTracksQuery(int id)
    {
        Id = id;
    }

    public int Id { get; init; } = default!;
}

public class GetAlbumTracksQueryHandler : IRequestHandler<GetAlbumTracksQuery, List<TrackDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAlbumTracksQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<TrackDto>> Handle(GetAlbumTracksQuery request, CancellationToken cancellationToken)
    {
        var album = await _context.Albums.Include(t => t.Tracks).FirstAsync(t => t.Id == request.Id);
        return _mapper.Map<List<TrackDto>>(album.Tracks);
    }
}