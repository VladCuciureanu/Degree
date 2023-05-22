namespace AudioStreaming.Domain.Entities;

public class Track : BaseAuditableEntity
{
    public string Title { get; set; } = default!;

    public int AlbumId { get; set; }
    public Album Album { get; set; } = null!;

    public IList<Artist> Artists { get; private set; } = new List<Artist>();
}
