namespace AudioStreaming.Domain.Events;

public class TrackArtistAddedEvent : BaseEvent
{
    public TrackArtistAddedEvent(Track item)
    {
        Item = item;
    }

    public Track Item { get; }
}
