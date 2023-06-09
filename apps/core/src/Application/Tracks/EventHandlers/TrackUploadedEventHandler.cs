using AudioStreaming.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AudioStreaming.Application.Tracks.EventHandlers;

public class TrackUploadedEventHandler : INotificationHandler<TrackUploadedEvent>
{
    private readonly ILogger<TrackUploadedEventHandler> _logger;

    public TrackUploadedEventHandler(ILogger<TrackUploadedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(TrackUploadedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("AudioStreaming Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}