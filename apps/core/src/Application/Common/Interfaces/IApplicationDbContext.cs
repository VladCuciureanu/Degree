using AudioStreaming.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AudioStreaming.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Artist> Artists { get; }

    DbSet<Album> Albums { get; }

    DbSet<Track> Tracks { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
