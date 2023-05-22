namespace AudioStreaming.Domain.Entities;

public class Artist : BaseAuditableEntity
{
    public string Name { get; set; }

    public string? ImageUrl { get; set; }

    public IList<Album> Albums { get; private set; } = new List<Album>();

    public IList<Track> Tracks { get; private set; } = new List<Track>();
}
