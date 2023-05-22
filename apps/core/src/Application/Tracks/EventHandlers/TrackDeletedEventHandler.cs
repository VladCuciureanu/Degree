using AudioStreaming.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AudioStreaming.Application.Tracks.EventHandlers;

public class TrackDeletedEventHandler : INotificationHandler<TrackDeletedEvent>
{
    private readonly ILogger<TrackDeletedEventHandler> _logger;

    public TrackDeletedEventHandler(ILogger<TrackDeletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(TrackDeletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("AudioStreaming Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
