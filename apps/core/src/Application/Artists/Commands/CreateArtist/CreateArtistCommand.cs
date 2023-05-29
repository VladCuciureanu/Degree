using AudioStreaming.Application.Common.Interfaces;
using AudioStreaming.Domain.Entities;
using AudioStreaming.Domain.Events;
using MediatR;

namespace AudioStreaming.Application.Artists.Commands.CreateArtist;

public record CreateArtistCommand : IRequest<int>
{
    public string Name { get; init; } = default!;

    public string? ImageUrl { get; init; } = null!;
}

public class CreateArtistCommandHandler : IRequestHandler<CreateArtistCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateArtistCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateArtistCommand request, CancellationToken cancellationToken)
    {
        var entity = new Artist
        {
            Name = request.Name,
            ImageUrl = request.ImageUrl
        };

        entity.AddDomainEvent(new ArtistCreatedEvent(entity));

        _context.Artists.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}