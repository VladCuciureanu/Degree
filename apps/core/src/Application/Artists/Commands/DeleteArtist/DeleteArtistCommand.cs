using AudioStreaming.Application.Common.Exceptions;
using AudioStreaming.Application.Common.Interfaces;
using AudioStreaming.Domain.Entities;
using AudioStreaming.Domain.Events;
using MediatR;

namespace AudioStreaming.Application.Artists.Commands.DeleteArtist;

public record DeleteArtistCommand(int Id) : IRequest;

public class DeleteArtistCommandHandler : IRequestHandler<DeleteArtistCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteArtistCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteArtistCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Artists
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Artist), request.Id);
        }

        _context.Artists.Remove(entity);

        entity.AddDomainEvent(new ArtistDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}