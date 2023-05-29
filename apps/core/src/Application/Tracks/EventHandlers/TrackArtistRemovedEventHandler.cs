using AudioStreaming.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AudioStreaming.Application.Tracks.EventHandlers;

public class TrackArtistRemovedEventHandler : INotificationHandler<TrackArtistRemovedEvent>
{
    private readonly ILogger<TrackArtistRemovedEventHandler> _logger;

    public TrackArtistRemovedEventHandler(ILogger<TrackArtistRemovedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(TrackArtistRemovedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("AudioStreaming Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
