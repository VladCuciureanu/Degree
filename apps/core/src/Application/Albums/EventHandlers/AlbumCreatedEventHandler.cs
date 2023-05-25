using AudioStreaming.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AudioStreaming.Application.Albums.EventHandlers;

public class AlbumCreatedEventHandler : INotificationHandler<AlbumCreatedEvent>
{
    private readonly ILogger<AlbumCreatedEventHandler> _logger;

    public AlbumCreatedEventHandler(ILogger<AlbumCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(AlbumCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("AudioStreaming Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
