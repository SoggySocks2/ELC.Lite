using ELC.Lite.CoreApp.Api.Leads;
using ELC.Lite.CoreApp.Infrastucture;
using ELC.Lite.CoreApp.Infrastucture.Leads;
using ELC.Lite.Domain.Leads.Contracts;
using ELC.Lite.SharedKernel.ConfigurationSettings;
using ELC.Lite.Web.Api.Setup.Extensions.Automapper;
using Microsoft.EntityFrameworkCore;

namespace ELC.Lite.Web.Api.Setup
{
    public static class CoreAppServices
    {
        public static void AddCoreAppServices(this WebApplicationBuilder builder, CoreAppSettings coreAppSettings)
        {
            //builder.Services.AddCustomAutoMapper(typeof(CoreAppApiMarker).Assembly, typeof(CoreAppInfrastructureMarker).Assembly);
            builder.Services.AddAutoMapperConfiguration();

            builder.AddCoreDbContext(coreAppSettings);
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services.AddLeadServices();
        }

        private static void AddCoreDbContext(this WebApplicationBuilder builder, CoreAppSettings coreAppSettings)
        {
            var connectionString = coreAppSettings.DbConnectionString ?? throw new InvalidOperationException("Connection string 'Core - DbConnectionString' not found.");
            builder.Services.AddDbContext<CoreDbContext>(options =>
                options.UseSqlServer(connectionString, sqlServerOptions =>
                {
                    if (coreAppSettings.DbTimeout is not null)
                    {
                        sqlServerOptions.CommandTimeout(coreAppSettings.DbTimeout.Value);
                    }
                })
            );
        }

        private static void AddLeadServices(this IServiceCollection services)
        {
            services.AddScoped<ILeadRepository, LeadRepository>();
            services.AddScoped<ILeadService, LeadService>();
        }
    }
}
