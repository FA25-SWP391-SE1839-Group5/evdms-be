using EVDMS.Common.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EVDMS.BusinessLogicLayer.DependencyInjection
{
    public static class ConfigurationRegistration
    {
        public static IServiceCollection AddConfigurations(
            this IServiceCollection services,
            IConfiguration config
        )
        {
            services.Configure<CloudinarySettings>(config.GetSection("Cloudinary"));
            services.Configure<EmailSettings>(config.GetSection("Email"));
            services.Configure<JwtSettings>(config.GetSection("Jwt"));

            return services;
        }
    }
}
