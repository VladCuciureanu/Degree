namespace AudioStreaming.Domain.Events;

public class AlbumCreatedEvent : BaseEvent
{
    public AlbumCreatedEvent(Album item)
    {
        Item = item;
    }

    public Album Item { get; }
}
