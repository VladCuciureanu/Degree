using AudioStreaming.Application.Common.Exceptions;
using AudioStreaming.Application.Common.Interfaces;
using AudioStreaming.Domain.Entities;
using AudioStreaming.Domain.Events;
using MediatR;

namespace AudioStreaming.Application.Albums.Commands.DeleteAlbum;

public record DeleteAlbumCommand(int Id) : IRequest;

public class DeleteAlbumCommandHandler : IRequestHandler<DeleteAlbumCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteAlbumCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteAlbumCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Albums
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Album), request.Id);
        }

        _context.Albums.Remove(entity);

        entity.AddDomainEvent(new AlbumDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
