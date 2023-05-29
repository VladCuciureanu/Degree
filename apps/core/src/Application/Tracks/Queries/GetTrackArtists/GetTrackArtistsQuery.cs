using AutoMapper;
using AudioStreaming.Application.Common.Interfaces;
using AudioStreaming.Application.Common.Mappings;
using AudioStreaming.Application.Artists.Queries;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace AudioStreaming.Application.Tracks.Queries.GetTrackArtists;

public record GetTrackArtistsQuery : IRequest<List<ArtistDto>>
{
    public GetTrackArtistsQuery(int id)
    {
        Id = id;
    }

    public int Id { get; init; } = default!;
}

public class GetTrackArtistsQueryHandler : IRequestHandler<GetTrackArtistsQuery, List<ArtistDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTrackArtistsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ArtistDto>> Handle(GetTrackArtistsQuery request, CancellationToken cancellationToken)
    {
        var track = await _context.Tracks.Include(t => t.Artists).FirstAsync(t => t.Id == request.Id);
        return _mapper.Map<List<ArtistDto>>(track.Artists);
    }
}
