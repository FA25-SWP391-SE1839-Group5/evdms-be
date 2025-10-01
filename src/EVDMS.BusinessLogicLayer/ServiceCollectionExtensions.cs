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
            services.AddScoped<IAuditLogRepository, AuditLogRepository>();
            services.AddScoped<IAuditLogService, AuditLogService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IDealerContractRepository, DealerContractRepository>();
            services.AddScoped<IDealerContractService, DealerContractService>();
            services.AddScoped<IDealerRepository, DealerRepository>();
            services.AddScoped<IDealerService, DealerService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IOemInventoryRepository, OemInventoryRepository>();
            services.AddScoped<IOemInventoryService, OemInventoryService>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPromotionRepository, PromotionRepository>();
            services.AddScoped<IPromotionService, PromotionService>();
            services.AddScoped<IQuotationRepository, QuotationRepository>();
            services.AddScoped<IQuotationService, QuotationService>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<ISalesOrderRepository, SalesOrderRepository>();
            services.AddScoped<ISalesOrderService, SalesOrderService>();
            services.AddScoped<ITestDriveRepository, TestDriveRepository>();
            services.AddScoped<ITestDriveService, TestDriveService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IVehicleModelRepository, VehicleModelRepository>();
            services.AddScoped<IVehicleModelService, VehicleModelService>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IVehicleVariantRepository, VehicleVariantRepository>();
            services.AddScoped<IVehicleVariantService, VehicleVariantService>();
            services.AddScoped<ICloudinaryService, CloudinaryService>();

            // Register AutoMapper profiles
            services.AddAutoMapper(cfg => cfg.AddProfile<AuditLogProfile>());
            services.AddAutoMapper(cfg => cfg.AddProfile<AuthProfile>());
            services.AddAutoMapper(cfg => cfg.AddProfile<CustomerProfile>());
            services.AddAutoMapper(cfg => cfg.AddProfile<DealerContractProfile>());
            services.AddAutoMapper(cfg => cfg.AddProfile<DealerProfile>());
            services.AddAutoMapper(cfg => cfg.AddProfile<FeedbackProfile>());
            services.AddAutoMapper(cfg => cfg.AddProfile<OemInventoryProfile>());
            services.AddAutoMapper(cfg => cfg.AddProfile<PaymentProfile>());
            services.AddAutoMapper(cfg => cfg.AddProfile<PromotionProfile>());
            services.AddAutoMapper(cfg => cfg.AddProfile<QuotationProfile>());
            services.AddAutoMapper(cfg => cfg.AddProfile<SalesOrderProfile>());
            services.AddAutoMapper(cfg => cfg.AddProfile<TestDriveProfile>());
            services.AddAutoMapper(cfg => cfg.AddProfile<UserProfile>());
            services.AddAutoMapper(cfg => cfg.AddProfile<VehicleModelProfile>());
            services.AddAutoMapper(cfg => cfg.AddProfile<VehicleProfile>());
            services.AddAutoMapper(cfg => cfg.AddProfile<VehicleVariantProfile>());

            return services;
        }
    }
}
