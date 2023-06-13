using AudioStreaming.Application.Common.Interfaces;
using AudioStreaming.Domain.Entities;
using AudioStreaming.Domain.Events;
using MediatR;

namespace AudioStreaming.Application.Tracks.Commands.CreateTrack;

public record CreateTrackCommand : IRequest<int>
{
    public string Name { get; init; } = default!;

    public int Number { get; init; } = default!;

    public int AlbumId { get; init; } = default!;
}

public class CreateTrackCommandHandler : IRequestHandler<CreateTrackCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateTrackCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateTrackCommand request, CancellationToken cancellationToken)
    {
        var entity = new Track
        {
            Name = request.Name,
            Number = request.Number,
            AlbumId = request.AlbumId
        };

        entity.AddDomainEvent(new TrackCreatedEvent(entity));

        _context.Tracks.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}