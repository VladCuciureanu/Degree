using AudioStreaming.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AudioStreaming.Application.Tracks.EventHandlers;

public class TrackArtistAddedEventHandler : INotificationHandler<TrackArtistAddedEvent>
{
    private readonly ILogger<TrackArtistAddedEventHandler> _logger;

    public TrackArtistAddedEventHandler(ILogger<TrackArtistAddedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(TrackArtistAddedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("AudioStreaming Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
