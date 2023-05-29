﻿namespace AudioStreaming.Domain.Entities;

public class Track : BaseAuditableEntity
{
    public string Name { get; set; } = default!;

    public int AlbumId { get; set; } = default!;
    public Album Album { get; set; } = null!;

    public List<Artist> Artists { get; private set; } = new();
}