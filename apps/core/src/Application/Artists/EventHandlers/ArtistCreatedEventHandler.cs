using AudioStreaming.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AudioStreaming.Application.Artists.EventHandlers;

public class ArtistCreatedEventHandler : INotificationHandler<ArtistCreatedEvent>
{
    private readonly ILogger<ArtistCreatedEventHandler> _logger;

    public ArtistCreatedEventHandler(ILogger<ArtistCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(ArtistCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("AudioStreaming Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
