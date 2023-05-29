using AudioStreaming.Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AudioStreaming.Application.Albums.Queries.GetAlbum;

public record GetAlbumQuery : IRequest<AlbumDto>
{
    public GetAlbumQuery(int id)
    {
        Id = id;
    }

    public int Id { get; init; } = default!;
}

public class GetAlbumQueryHandler : IRequestHandler<GetAlbumQuery, AlbumDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAlbumQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<AlbumDto> Handle(GetAlbumQuery request, CancellationToken cancellationToken)
    {
        return await _context.Albums
            .Include(a => a.Artist)
            .ProjectTo<AlbumDto>(_mapper.ConfigurationProvider)
            .FirstAsync(it => it.Id == request.Id);
    }
}