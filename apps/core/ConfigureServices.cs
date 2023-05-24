using AudioStreaming.Services.AlbumService;
using AudioStreaming.Services.ArtistService;
using AudioStreaming.Services.TrackService;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
  public static IServiceCollection AddServices(this IServiceCollection services)
  {
    services.AddScoped<IAlbumService, AlbumService>();
    services.AddScoped<IArtistService, ArtistService>();
    services.AddScoped<ITrackService, TrackService>();

    return services;
  }
}