using AudioStreaming.Application.Common.Exceptions;
using AudioStreaming.Application.Common.Interfaces;
using AudioStreaming.Domain.Entities;
using MediatR;

namespace AudioStreaming.Application.Albums.Commands.UpdateAlbum;

public record UpdateAlbumCommand : IRequest
{
    public int Id { get; init; }

    public string? Name { get; init; }

    public string? ImageUrl { get; init; }

    public int? ArtistId { get; init; }
}

public class UpdateAlbumCommandHandler : IRequestHandler<UpdateAlbumCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateAlbumCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateAlbumCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Albums
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Album), request.Id);
        }

        entity.Name = request.Name != null ? request.Name : entity.Name;

        entity.ImageUrl = request.ImageUrl;

        entity.ArtistId = request.ArtistId != null ? (int)request.ArtistId : entity.ArtistId;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}