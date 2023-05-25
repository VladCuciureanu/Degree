namespace AudioStreaming.Domain.Events;

public class ArtistCreatedEvent : BaseEvent
{
    public ArtistCreatedEvent(Artist item)
    {
        Item = item;
    }

    public Artist Item { get; }
}
