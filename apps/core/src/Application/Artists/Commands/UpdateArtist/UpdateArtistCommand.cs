using AudioStreaming.Application.Common.Exceptions;
using AudioStreaming.Application.Common.Interfaces;
using AudioStreaming.Domain.Entities;
using MediatR;

namespace AudioStreaming.Application.Artists.Commands.UpdateArtist;

public record UpdateArtistCommand : IRequest
{
    public int Id { get; init; }

    public string? Name { get; init; }
}

public class UpdateArtistCommandHandler : IRequestHandler<UpdateArtistCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateArtistCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateArtistCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Artists
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Artist), request.Id);
        }

        if (request.Name != null)
        {
            entity.Name = request.Name;
        }

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
