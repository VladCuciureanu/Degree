using AudioStreaming.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AudioStreaming.Application.Albums.EventHandlers;

public class AlbumDeletedEventHandler : INotificationHandler<AlbumDeletedEvent>
{
    private readonly ILogger<AlbumDeletedEventHandler> _logger;

    public AlbumDeletedEventHandler(ILogger<AlbumDeletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(AlbumDeletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("AudioStreaming Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
