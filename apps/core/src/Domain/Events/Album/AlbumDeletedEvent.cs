namespace AudioStreaming.Domain.Events;

public class AlbumDeletedEvent : BaseEvent
{
    public AlbumDeletedEvent(Album item)
    {
        Item = item;
    }

    public Album Item { get; }
}