using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AudioStreaming.Data
{
  public class IdentityContext : IdentityDbContext<User>
  {
    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);
      optionsBuilder.UseInMemoryDatabase("AudioStreamingIdentityDb");
    }
  }
}
