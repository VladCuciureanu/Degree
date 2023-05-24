global using Microsoft.EntityFrameworkCore;

namespace AudioStreaming.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);
      optionsBuilder.UseInMemoryDatabase("AudioStreamingDb");
    }

    public DbSet<Album> Albums { get; set; } = default!;
    public DbSet<Artist> Artists { get; set; } = default!;
    public DbSet<Track> Tracks { get; set; } = default!;
  }
}
