namespace AudioStreaming.Domain.Entities;

public class Album : BaseAuditableEntity
{
    public string Title { get; set; } = default!;

    public AlbumType Type { get; set; }

    public int ArtistId { get; set; }
    public Artist Artist { get; set; } = null!;

    public IList<Track> Tracks { get; private set; } = new List<Track>();
}
