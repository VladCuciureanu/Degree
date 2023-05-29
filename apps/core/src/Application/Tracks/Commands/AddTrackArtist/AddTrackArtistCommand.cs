using AudioStreaming.Application.Common.Exceptions;
using AudioStreaming.Application.Common.Interfaces;
using AudioStreaming.Domain.Entities;
using MediatR;

namespace AudioStreaming.Application.Tracks.Commands.UpdateTrack;

public record AddTrackArtistCommand : IRequest
{
    public int TrackId { get; init; }

    public int ArtistId { get; init; }
}

public class AddTrackArtistCommandHandler : IRequestHandler<AddTrackArtistCommand>
{
    private readonly IApplicationDbContext _context;

    public AddTrackArtistCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(AddTrackArtistCommand request, CancellationToken cancellationToken)
    {
        var track = await _context.Tracks
            .FindAsync(new object[] { request.TrackId }, cancellationToken);

        if (track == null)
        {
            throw new NotFoundException(nameof(Track), request.TrackId);
        }

        var artist = await _context.Artists
            .FindAsync(new object[] { request.ArtistId }, cancellationToken);

        if (artist == null)
        {
            throw new NotFoundException(nameof(Artist), request.ArtistId);
        }

        track.Artists.Add(artist);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
