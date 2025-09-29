using EVDMS.BusinessLogicLayer.MappingProfiles;
using EVDMS.BusinessLogicLayer.Services.Implementations;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.DataAccessLayer.Repositories.Implementations;
using EVDMS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EVDMS.BusinessLogicLayer
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            // Register repos & services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IDealerRepository, DealerRepository>();
            services.AddScoped<IDealerService, DealerService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            // Register AutoMapper profiles
            services.AddAutoMapper(cfg => cfg.AddProfile<CustomerProfile>());
            services.AddAutoMapper(cfg => cfg.AddProfile<UserProfile>());
            services.AddAutoMapper(cfg => cfg.AddProfile<AuthProfile>());
            services.AddAutoMapper(cfg => cfg.AddProfile<DealerProfile>());

            return services;
        }
    }
}
