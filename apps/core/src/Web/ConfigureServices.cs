using AudioStreaming.Application.Common.Interfaces;
using AudioStreaming.Web.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddScoped<ICurrentUserService, CurrentUserService>();

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen();

        return services;
    }
}
