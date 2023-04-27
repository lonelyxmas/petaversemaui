using Microsoft.Extensions.DependencyInjection;

namespace petaverse.frontend.core;

public static class ServiceExtensions
{
    public static void RegisterPetaverseFrontEndCoreServices(this IServiceCollection services)
    {
        services.AddScoped<ISpeciesService, FakeSpeciesService>();
    }
}
