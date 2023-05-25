using AudioStreaming.Application.Common.Interfaces;
using AudioStreaming.Domain.Entities;
using AudioStreaming.Domain.Events;
using MediatR;

namespace AudioStreaming.Application.Albums.Commands.CreateAlbum;

public record CreateAlbumCommand : IRequest<int>
{
    public int ArtistId { get; init; }

    public string Title { get; init; } = default!;
}

public class CreateAlbumCommandHandler : IRequestHandler<CreateAlbumCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateAlbumCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateAlbumCommand request, CancellationToken cancellationToken)
    {
        var entity = new Album
        {
            Title = request.Title,
            ArtistId = request.ArtistId,
        };

        entity.AddDomainEvent(new AlbumCreatedEvent(entity));

        _context.Albums.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
