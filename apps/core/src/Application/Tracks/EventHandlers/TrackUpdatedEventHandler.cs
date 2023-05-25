using AudioStreaming.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AudioStreaming.Application.Tracks.EventHandlers;

public class TrackUpdatedEventHandler : INotificationHandler<TrackUpdatedEvent>
{
    private readonly ILogger<TrackUpdatedEventHandler> _logger;

    public TrackUpdatedEventHandler(ILogger<TrackUpdatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(TrackUpdatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("AudioStreaming Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
