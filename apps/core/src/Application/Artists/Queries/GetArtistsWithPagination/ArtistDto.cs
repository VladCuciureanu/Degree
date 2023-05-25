using AudioStreaming.Application.Common.Mappings;
using AudioStreaming.Domain.Entities;

namespace AudioStreaming.Application.Artists.Queries.GetArtistsWithPagination;

public class ArtistDto : IMapFrom<Artist>
{
    public int Id { get; set; } = default!;

    public string Name { get; set; } = default!;

    public string? ImageUrl { get; set; } = null!;
}
