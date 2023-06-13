using AudioStreaming.Application.Common.Mappings;
using AudioStreaming.Domain.Entities;

namespace AudioStreaming.Application.Albums.Queries;

public class AlbumDto : IMapFrom<Album>
{
    public int Id { get; set; } = default!;

    public string Name { get; set; } = default!;

    public string? ImageUrl { get; set; } = null!;

    public string Type { get; set; } = default!;

    public Artist Artist { get; set; } = default!;
}