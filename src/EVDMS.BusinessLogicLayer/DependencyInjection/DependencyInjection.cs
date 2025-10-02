using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EVDMS.BusinessLogicLayer.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(
            this IServiceCollection services,
            IConfiguration config
        )
        {
            services.AddRepositories().AddServices().AddMappingProfiles().AddConfigurations(config);

            return services;
        }
    }
}
