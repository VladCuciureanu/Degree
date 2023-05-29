namespace AudioStreaming.Domain.Events;

public class AlbumUpdatedEvent : BaseEvent
{
    public AlbumUpdatedEvent(Album item)
    {
        Item = item;
    }

    public Album Item { get; }
}