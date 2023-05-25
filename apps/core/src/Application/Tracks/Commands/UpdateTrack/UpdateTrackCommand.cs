using AudioStreaming.Application.Common.Exceptions;
using AudioStreaming.Application.Common.Interfaces;
using AudioStreaming.Domain.Entities;
using MediatR;

namespace AudioStreaming.Application.Tracks.Commands.UpdateTrack;

public record UpdateTrackCommand : IRequest
{
    public int Id { get; init; }

    public string? Name { get; init; }

    public int? AlbumId { get; init; }
}

public class UpdateTrackCommandHandler : IRequestHandler<UpdateTrackCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateTrackCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateTrackCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Tracks
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Track), request.Id);
        }

        entity.Name = request.Name != null ? request.Name : entity.Name;

        entity.AlbumId = request.AlbumId != null ? (int)request.AlbumId : entity.AlbumId;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
