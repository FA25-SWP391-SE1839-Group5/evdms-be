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
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserTokenRepository, UserTokenRepository>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IDealerRepository, DealerRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddAutoMapper(cfg => cfg.AddProfile<CustomerProfile>());
            services.AddAutoMapper(cfg => cfg.AddProfile<AuthProfile>());
            services.AddAutoMapper(cfg => cfg.AddProfile<RoleProfile>());

            return services;
        }
    }
}
