namespace AudioStreaming.Domain.Events;

public class TrackUpdatedEvent : BaseEvent
{
    public TrackUpdatedEvent(Track item)
    {
        Item = item;
    }

    public Track Item { get; }
}
