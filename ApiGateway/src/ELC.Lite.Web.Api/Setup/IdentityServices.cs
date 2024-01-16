using ELC.Lite.Identity.Api.Identities;
using ELC.Lite.Identity.Infrastructure;
using ELC.Lite.Identity.Infrastructure.Identities;
using ELC.Lite.SharedKernel.ConfigurationSettings;
using ELC.Lite.Web.Api.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ELC.Lite.Web.Api.Setup
{
    public static class IdentityServices
    {
        public static void AddIdentityServices(this WebApplicationBuilder builder, IdentitySettings identitySettings)
        {
            builder.AddIdentityDbContext(identitySettings);
            builder.AddIdentity();
            builder.AddIdentityServices();
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
            builder.Services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
            .AddEntityFrameworkStores<ElcIdentityDbContext>();
            builder.Services.AddControllersWithViews();
        }


        private static void AddIdentityServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IIdentityRepository, IdentityRepository>();
            builder.Services.AddScoped<IIdentityService, IdentityService>();
            builder.Services.AddScoped<IIdentityProxy, IdentityProxy>();
        }
    }
}
