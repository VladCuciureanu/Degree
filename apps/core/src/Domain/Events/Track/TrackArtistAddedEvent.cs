namespace AudioStreaming.Domain.Events;

public class TrackArtistAddedEvent : BaseEvent
{
    public TrackArtistAddedEvent(Track track, Artist artist)
    {
        Track = track;
        Artist = artist;
    }

    public Track Track { get; }

    public Artist Artist { get; }
}