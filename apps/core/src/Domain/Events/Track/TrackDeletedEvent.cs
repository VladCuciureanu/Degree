namespace AudioStreaming.Domain.Events;

public class TrackDeletedEvent : BaseEvent
{
    public TrackDeletedEvent(Track item)
    {
        Item = item;
    }

    public Track Item { get; }
}
