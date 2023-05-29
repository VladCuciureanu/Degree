using AudioStreaming.Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AudioStreaming.Application.Artists.Queries.GetArtist;

public record GetArtistQuery : IRequest<ArtistDto>
{
    public GetArtistQuery(int id)
    {
        Id = id;
    }

    public int Id { get; init; } = default!;
}

public class GetArtistQueryHandler : IRequestHandler<GetArtistQuery, ArtistDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetArtistQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ArtistDto> Handle(GetArtistQuery request, CancellationToken cancellationToken)
    {
        return await _context.Artists
            .ProjectTo<ArtistDto>(_mapper.ConfigurationProvider)
            .FirstAsync(it => it.Id == request.Id);
    }
}