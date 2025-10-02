using EVDMS.BusinessLogicLayer.Services.Implementations;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EVDMS.BusinessLogicLayer.DependencyInjection
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuditLogService, AuditLogService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICloudinaryService, CloudinaryService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IDealerContractService, DealerContractService>();
            services.AddScoped<IDealerService, DealerService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IOemInventoryService, OemInventoryService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPromotionService, PromotionService>();
            services.AddScoped<IQuotationService, QuotationService>();
            services.AddScoped<ISalesOrderService, SalesOrderService>();
            services.AddScoped<ITestDriveService, TestDriveService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IVehicleModelService, VehicleModelService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IVehicleVariantService, VehicleVariantService>();

            return services;
        }
    }
}
