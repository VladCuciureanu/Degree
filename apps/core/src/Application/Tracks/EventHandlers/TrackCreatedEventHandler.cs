using AudioStreaming.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AudioStreaming.Application.Tracks.EventHandlers;

public class TrackCreatedEventHandler : INotificationHandler<TrackCreatedEvent>
{
    private readonly ILogger<TrackCreatedEventHandler> _logger;

    public TrackCreatedEventHandler(ILogger<TrackCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(TrackCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("AudioStreaming Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
