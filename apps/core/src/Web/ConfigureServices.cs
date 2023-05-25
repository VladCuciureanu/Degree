using AudioStreaming.Application.Common.Interfaces;
using AudioStreaming.Web.Services;
using Microsoft.OpenApi.Models;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        // Setup services
        services.AddDatabaseDeveloperPageExceptionFilter();
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        // Configure Swagger
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            OpenApiSecurityScheme securityDefinition = new OpenApiSecurityScheme()
            {
                BearerFormat = "JWT",
                Scheme = "bearer",
                Description = "Specify the authorization token.",
                Type = SecuritySchemeType.Http,
            };

            options.AddSecurityDefinition("Bearer", securityDefinition);

            OpenApiSecurityRequirement securityRequirements = new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                    },
                    new string[] {}
                }
            };

            options.AddSecurityRequirement(securityRequirements);
        });

        return services;
    }
}
