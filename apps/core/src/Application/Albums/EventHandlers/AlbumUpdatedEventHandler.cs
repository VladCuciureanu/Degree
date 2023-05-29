using AudioStreaming.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AudioStreaming.Application.Albums.EventHandlers;

public class AlbumUpdatedEventHandler : INotificationHandler<AlbumUpdatedEvent>
{
    private readonly ILogger<AlbumUpdatedEventHandler> _logger;

    public AlbumUpdatedEventHandler(ILogger<AlbumUpdatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(AlbumUpdatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("AudioStreaming Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}