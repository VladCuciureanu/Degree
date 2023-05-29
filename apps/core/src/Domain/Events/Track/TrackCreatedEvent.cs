namespace AudioStreaming.Domain.Events;

public class TrackCreatedEvent : BaseEvent
{
    public TrackCreatedEvent(Track item)
    {
        Item = item;
    }

    public Track Item { get; }
}