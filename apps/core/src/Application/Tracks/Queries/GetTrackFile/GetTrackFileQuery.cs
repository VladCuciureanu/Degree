using AudioStreaming.Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AudioStreaming.Application.Tracks.Queries.GetTrackFile;

public record GetTrackFileQuery : IRequest<String?>
{
    public GetTrackFileQuery(int id)
    {
        Id = id;
    }

    public int Id { get; init; } = default!;
}

public class GetTrackFileQueryHandler : IRequestHandler<GetTrackFileQuery, String?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTrackFileQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<String?> Handle(GetTrackFileQuery request, CancellationToken cancellationToken)
    {
        return (await _context.Tracks.FirstAsync(it => it.Id == request.Id)).Url;
    }
}