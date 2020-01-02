using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebAsada.Helpers;
using WebAsada.Interfaces;
using WebAsada.Repository;
using WebAsada.Services;

namespace WebAsada
{
    public static class ServiceExtension
    {
        public static void ConfigureHttpClients(this IServiceCollection services, IConfiguration configuration)
        { 
            services.AddHttpClient("PdfGeneratorApi", c =>
            {
                c.BaseAddress = new Uri(configuration.GetValue<string>("Endpoints:PdfGeneratorApi"));
            });


            services.AddHttpClient("QrGeneratorApi", c =>
            {
                c.BaseAddress = new Uri(configuration.GetValue<string>("Endpoints:QrGeneratorApi"));
            });

        }

        public static void ConfigureService(this IServiceCollection services)
        {
            services.AddTransient<ChargeRepository>();
            services.AddTransient<PersonTypeRepository>();
            services.AddTransient<EntityRepository>();
            services.AddTransient<MonthRepository>();
            services.AddTransient<MeasurementRepository>();
            services.AddTransient<EstateRepository>();
            services.AddTransient<IdentificationTypeRepository>();
            services.AddTransient<ReceiptRepository>();
            services.AddTransient<PersonRepository>();
            services.AddTransient<PersonsByEstateRepository>();
            services.AddTransient<CurrencyRepository>();
            services.AddTransient<ContractTypeRepository>();
            services.AddTransient<SupplierReporsitory>();
            services.AddTransient<ProductTypeRepository>();
            services.AddTransient<WaterMeterRepository>();
            services.AddTransient<ContractRepository>();
            services.AddTransient<ChargeTypeRepository>(); 
            services.AddTransient<ILoggedUserReader, LoggedUser>();
            services.AddTransient<IYesNoOptions, YesNoOptions>();
        }
    }
}
