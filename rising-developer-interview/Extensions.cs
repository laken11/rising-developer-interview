using Mapster;
using MapsterMapper;
using Microsoft.OpenApi.Models;

namespace rising_developer_interview;

public static class Extensions
{
    public static void AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1",
                new()
                {
                    Title = "SMS Service",
                    Version = "v1",
                    Contact = new()
                    {
                        Name = "E-mail",
                        Email = "sms@gmail.com"
                    }
                });

            c.AddSecurityRequirement(new()
            {
                {
                    new()
                    {
                        Reference = new()
                        {
                            Id = "OAuth2",
                            Type = ReferenceType.SecurityScheme
                        },
                    },
                    new List<string>()
                }
            });
        });

    }

    public static IServiceCollection AddMapster(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Default.EnumMappingStrategy(EnumMappingStrategy.ByName);
        services.AddSingleton(config);
        services.AddTransient<IMapper, ServiceMapper>();
        return services;
    }
}