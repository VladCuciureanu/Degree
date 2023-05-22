namespace AudioStreaming.Domain.Events;

public class ArtistDeletedEvent : BaseEvent
{
    public ArtistDeletedEvent(Artist item)
    {
        Item = item;
    }

    public Artist Item { get; }
}
