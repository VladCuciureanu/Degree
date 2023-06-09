using AudioStreaming.Application.Common.Exceptions;
using AudioStreaming.Application.Common.Interfaces;
using AudioStreaming.Domain.Entities;
using AudioStreaming.Domain.Events;
using MediatR;

namespace AudioStreaming.Application.Tracks.Commands.UploadTrack;

public record UploadTrackCommand : IRequest
{
    public UploadTrackCommand(int id, byte[] payload, String basePath)
    {
        this.Id = id;
        this.Payload = payload;
        this.BasePath = basePath;
    }

    public int Id { get; init; }
    public byte[] Payload { get; init; }

    public String BasePath { get; init; }
}

public class UploadTrackCommandHandler : IRequestHandler<UploadTrackCommand>
{
    private readonly IApplicationDbContext _context;

    public UploadTrackCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UploadTrackCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Tracks
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Track), request.Id);
        }

        String fileName = Guid.NewGuid().ToString();
        File.WriteAllBytes(request.BasePath + "/" + fileName, request.Payload);

        entity.Url = fileName;

        entity.AddDomainEvent(new TrackUpdatedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}