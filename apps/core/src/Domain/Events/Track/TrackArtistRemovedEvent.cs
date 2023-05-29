namespace AudioStreaming.Domain.Events;

public class TrackArtistRemovedEvent : BaseEvent
{
    public TrackArtistRemovedEvent(Track item)
    {
        Item = item;
    }

    public Track Item { get; }
}
