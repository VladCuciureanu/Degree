namespace AudioStreaming.Domain.Events;

public class ArtistUpdatedEvent : BaseEvent
{
    public ArtistUpdatedEvent(Artist item)
    {
        Item = item;
    }

    public Artist Item { get; }
}