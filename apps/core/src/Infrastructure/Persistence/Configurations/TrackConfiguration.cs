using AudioStreaming.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AudioStreaming.Infrastructure.Persistence.Configurations;

public class TrackConfiguration : IEntityTypeConfiguration<Track>
{
    public void Configure(EntityTypeBuilder<Track> builder)
    {
        builder.Property(t => t.Name)
            .HasMaxLength(128)
            .IsRequired();

        builder.HasOne(t => t.Album).WithMany(a => a.Tracks).HasForeignKey(t => t.AlbumId);
    }
}