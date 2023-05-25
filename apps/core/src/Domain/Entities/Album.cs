namespace AudioStreaming.Domain.Entities;

public class Album : BaseAuditableEntity
{
    public string Name { get; set; } = default!;

    public string? ImageUrl { get; set; } = null!;

    public AlbumType Type { get; set; } = default!;

    public int ArtistId { get; set; } = default!;
    public Artist Artist { get; set; } = null!;

    public List<Track> Tracks { get; private set; } = new();
}
