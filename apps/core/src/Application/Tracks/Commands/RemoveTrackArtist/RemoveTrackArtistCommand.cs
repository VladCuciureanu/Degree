using AudioStreaming.Application.Common.Exceptions;
using AudioStreaming.Application.Common.Interfaces;
using AudioStreaming.Domain.Entities;
using AudioStreaming.Domain.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AudioStreaming.Application.Tracks.Commands.RemoveTrackArtist;

public record RemoveTrackArtistCommand : IRequest
{
    public int TrackId { get; init; }

    public int ArtistId { get; init; }
}

public class RemoveTrackArtistCommandHandler : IRequestHandler<RemoveTrackArtistCommand>
{
    private readonly IApplicationDbContext _context;

    public RemoveTrackArtistCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(RemoveTrackArtistCommand request, CancellationToken cancellationToken)
    {
        var track = await _context.Tracks
            .Include(t => t.Artists)
            .FirstAsync(t => t.Id == request.TrackId, cancellationToken);

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

        track.Artists.Remove(artist);

        track.AddDomainEvent(new TrackArtistRemovedEvent(track, artist));

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}