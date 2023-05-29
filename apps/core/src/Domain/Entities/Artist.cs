namespace AudioStreaming.Domain.Entities;

public class Artist : BaseAuditableEntity
{
    public string Name { get; set; } = default!;

    public string? ImageUrl { get; set; } = null!;

    public List<Album> Albums { get; private set; } = new();

    public List<Track> Tracks { get; private set; } = new();
}