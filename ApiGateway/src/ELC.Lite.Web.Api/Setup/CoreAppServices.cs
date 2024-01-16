using ELC.Lite.Core.Identity.Infrastructure;
using ELC.Lite.CoreApp.Api.Leads;
using ELC.Lite.CoreApp.Infrastucture;
using ELC.Lite.CoreApp.Infrastucture.Leads;
using ELC.Lite.Domain.Leads.Contracts;
using ELC.Lite.SharedKernel.ConfigurationSettings;
using ELC.Lite.Web.Api.Setup.Extensions.Automapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ELC.Lite.Web.Api.Setup
{
    public static class CoreAppServices
    {
        public static void AddCoreAppServices(this WebApplicationBuilder builder, IdentitySettings identitySettings, CoreAppSettings coreAppSettings)
        {
            //builder.Services.AddCustomAutoMapper(typeof(CoreAppApiMarker).Assembly, typeof(CoreAppInfrastructureMarker).Assembly);
            builder.Services.AddAutoMapperConfiguration();

            builder.AddIdentityDbContext(identitySettings);
            builder.AddIdentity();
            builder.AddCoreDbContext(coreAppSettings);
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services.AddLeadServices();
        }

        private static void AddIdentityDbContext(this WebApplicationBuilder builder, IdentitySettings identitySettings)
        {
            var connectionString = identitySettings.DbConnectionString ?? throw new InvalidOperationException("Connection string 'Identity - DbConnectionString' not found.");
            builder.Services.AddDbContext<ElcIdentityDbContext>(options =>
                options.UseSqlServer(connectionString, sqlServerOptions =>
                {
                    if (identitySettings.DbTimeout is not null)
                    {
                        sqlServerOptions.CommandTimeout(identitySettings.DbTimeout.Value);
                    }
                })
            );
        }
        private static void AddIdentity(this WebApplicationBuilder builder)
        {
            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ElcIdentityDbContext>();
            builder.Services.AddControllersWithViews();
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
