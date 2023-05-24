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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Album>().HasData(new { Id = 1, Name = "Fake Album 1" }, new { Id = 2, Name = "Fake Album 2" }, new { Id = 3, Name = "Fake Album 3" });

      modelBuilder.Entity<Artist>().HasData(new { Id = 1, Name = "Fake Artist 1" }, new { Id = 2, Name = "Fake Artist 2" }, new { Id = 3, Name = "Fake Artist 3" });

      modelBuilder.Entity<Track>().HasData(new { Id = 1, Name = "Fake Track 1" }, new { Id = 2, Name = "Fake Track 2" }, new { Id = 3, Name = "Fake Track 3" });
    }

    public DbSet<Album> Albums { get; set; } = default!;
    public DbSet<Artist> Artists { get; set; } = default!;
    public DbSet<Track> Tracks { get; set; } = default!;
  }
}
