using AutoMapper;
using AutoMapper.QueryableExtensions;
using AudioStreaming.Application.Common.Interfaces;
using AudioStreaming.Application.Common.Mappings;
using AudioStreaming.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AudioStreaming.Application.Tracks.Queries.GetTrack;

public record GetTrackQuery : IRequest<TrackDto>
{
    public GetTrackQuery(int id)
    {
        Id = id;
    }

    public int Id { get; init; } = default!;
}

public class GetTrackQueryHandler : IRequestHandler<GetTrackQuery, TrackDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTrackQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TrackDto> Handle(GetTrackQuery request, CancellationToken cancellationToken)
    {
        return await _context.Tracks
            .ProjectTo<TrackDto>(_mapper.ConfigurationProvider)
            .FirstAsync(it => it.Id == request.Id);
    }
}
