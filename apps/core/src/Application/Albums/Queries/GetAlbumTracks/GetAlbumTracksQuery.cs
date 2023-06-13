using AudioStreaming.Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
        return await _context.Tracks
            .Where(t => t.AlbumId == request.Id)
            .ProjectTo<TrackDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Number)
            .ToListAsync();
    }
}