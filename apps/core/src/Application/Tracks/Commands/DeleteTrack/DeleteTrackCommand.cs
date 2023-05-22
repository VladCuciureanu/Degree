using AudioStreaming.Application.Common.Exceptions;
using AudioStreaming.Application.Common.Interfaces;
using AudioStreaming.Domain.Entities;
using AudioStreaming.Domain.Events;
using MediatR;

namespace AudioStreaming.Application.Tracks.Commands.DeleteTrack;

public record DeleteTrackCommand(int Id) : IRequest;

public class DeleteTrackCommandHandler : IRequestHandler<DeleteTrackCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteTrackCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteTrackCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Tracks
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Track), request.Id);
        }

        _context.Tracks.Remove(entity);

        entity.AddDomainEvent(new TrackDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
