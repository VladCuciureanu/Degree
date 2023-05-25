using AudioStreaming.Application.Common.Mappings;
using AudioStreaming.Domain.Entities;

namespace AudioStreaming.Application.Albums.Queries.GetAlbumsWithPagination;

public class AlbumDto : IMapFrom<Album>
{
    public int Id { get; set; }

    public string? Title { get; set; }
}
