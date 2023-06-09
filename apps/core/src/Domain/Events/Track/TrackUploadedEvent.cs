namespace AudioStreaming.Domain.Events;

public class TrackUploadedEvent : BaseEvent
{
    public TrackUploadedEvent(Track item)
    {
        Item = item;
    }

    public Track Item { get; }
}