using AudioStreaming.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AudioStreaming.Application.Artists.EventHandlers;

public class ArtistUpdatedEventHandler : INotificationHandler<ArtistUpdatedEvent>
{
    private readonly ILogger<ArtistUpdatedEventHandler> _logger;

    public ArtistUpdatedEventHandler(ILogger<ArtistUpdatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(ArtistUpdatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("AudioStreaming Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}