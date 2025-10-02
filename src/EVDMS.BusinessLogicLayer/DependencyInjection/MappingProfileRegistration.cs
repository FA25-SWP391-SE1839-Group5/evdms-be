using EVDMS.BusinessLogicLayer.MappingProfiles;
using Microsoft.Extensions.DependencyInjection;

namespace EVDMS.BusinessLogicLayer.DependencyInjection
{
    public static class MappingProfileRegistration
    {
        public static IServiceCollection AddMappingProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<AuditLogProfile>();
                cfg.AddProfile<AuthProfile>();
                cfg.AddProfile<CustomerProfile>();
                cfg.AddProfile<DealerContractProfile>();
                cfg.AddProfile<DealerProfile>();
                cfg.AddProfile<FeedbackProfile>();
                cfg.AddProfile<OemInventoryProfile>();
                cfg.AddProfile<PaymentProfile>();
                cfg.AddProfile<PromotionProfile>();
                cfg.AddProfile<QuotationProfile>();
                cfg.AddProfile<SalesOrderProfile>();
                cfg.AddProfile<TestDriveProfile>();
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<VehicleModelProfile>();
                cfg.AddProfile<VehicleProfile>();
                cfg.AddProfile<VehicleVariantProfile>();
            });

            return services;
        }
    }
}
