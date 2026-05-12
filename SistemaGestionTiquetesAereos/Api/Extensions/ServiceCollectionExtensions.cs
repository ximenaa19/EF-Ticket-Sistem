using AirlineTicketSystem.Api.Mappings;
using Mapster;
using MapsterMapper;

namespace AirlineTicketSystem.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        MappingConfig.RegisterMappings(config);

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }
}
