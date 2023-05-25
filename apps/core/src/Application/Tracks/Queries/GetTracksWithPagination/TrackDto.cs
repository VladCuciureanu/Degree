using AudioStreaming.Application.Common.Mappings;
using AudioStreaming.Domain.Entities;

namespace AudioStreaming.Application.Tracks.Queries.GetTracksWithPagination;

public class TrackDto : IMapFrom<Track>
{
    public int Id { get; set; } = default!;

    public string Name { get; set; } = default!;

    public int AlbumId { get; set; } = default!;
}
