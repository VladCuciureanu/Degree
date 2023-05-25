using AudioStreaming.Application.Common.Interfaces;
using AudioStreaming.Domain.Entities;
using AudioStreaming.Domain.Events;
using MediatR;

namespace AudioStreaming.Application.Albums.Commands.CreateAlbum;

public record CreateAlbumCommand : IRequest<int>
{
    public string Name { get; init; } = default!;

    public string? ImageUrl { get; init; } = null!;

    public int ArtistId { get; init; } = default!;
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
            Name = request.Name,
            ImageUrl = request.ImageUrl,
            ArtistId = request.ArtistId
        };

        entity.AddDomainEvent(new AlbumCreatedEvent(entity));

        _context.Albums.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
