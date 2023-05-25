using AudioStreaming.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AudioStreaming.Application.Artists.EventHandlers;

public class ArtistDeletedEventHandler : INotificationHandler<ArtistDeletedEvent>
{
    private readonly ILogger<ArtistDeletedEventHandler> _logger;

    public ArtistDeletedEventHandler(ILogger<ArtistDeletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(ArtistDeletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("AudioStreaming Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
