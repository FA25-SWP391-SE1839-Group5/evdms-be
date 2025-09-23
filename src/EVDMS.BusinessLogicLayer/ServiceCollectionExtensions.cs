using System.Reflection;
using AutoMapper;
using AutoMapper.Configuration;
using EVDMS.BusinessLogicLayer.Mapping;
using EVDMS.BusinessLogicLayer.Services.Implementations;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.DataAccessLayer.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace EVDMS.BusinessLogicLayer
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICustomerService, CustomerService>();

            services.AddAutoMapper(cfg => cfg.AddProfile<CustomerProfile>());

            return services;
        }
    }
}
