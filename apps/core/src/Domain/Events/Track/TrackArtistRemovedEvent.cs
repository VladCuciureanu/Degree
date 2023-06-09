namespace AudioStreaming.Domain.Events;

public class TrackArtistRemovedEvent : BaseEvent
{
    public TrackArtistRemovedEvent(Track track, Artist artist)
    {
        Track = track;
    }

    public Track Track { get; }
}