using AudioStreaming.Application.Common.Mappings;
using AudioStreaming.Domain.Entities;

namespace AudioStreaming.Application.Tracks.Queries.GetTracksWithPagination;

public class TrackDto : IMapFrom<Track>
{
    public int Id { get; set; }

    public string? Title { get; set; }
}
