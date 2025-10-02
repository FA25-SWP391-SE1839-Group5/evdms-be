using EVDMS.DataAccessLayer.Repositories.Implementations;
using EVDMS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EVDMS.BusinessLogicLayer.DependencyInjection
{
    public static class RepositoryRegistration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAuditLogRepository, AuditLogRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IDealerContractRepository, DealerContractRepository>();
            services.AddScoped<IDealerRepository, DealerRepository>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IOemInventoryRepository, OemInventoryRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPromotionRepository, PromotionRepository>();
            services.AddScoped<IQuotationRepository, QuotationRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<ISalesOrderRepository, SalesOrderRepository>();
            services.AddScoped<ITestDriveRepository, TestDriveRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IVehicleModelRepository, VehicleModelRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IVehicleVariantRepository, VehicleVariantRepository>();

            return services;
        }
    }
}
