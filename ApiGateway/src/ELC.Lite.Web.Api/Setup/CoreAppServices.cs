using ELC.Lite.CoreApp.Api.Leads;
using ELC.Lite.CoreApp.Infrastucture;
using ELC.Lite.CoreApp.Infrastucture.Leads;
using ELC.Lite.Domain.Leads.Contracts;
using ELC.Lite.Web.Api.Setup.Extensions.Automapper;
using Microsoft.EntityFrameworkCore;

namespace ELC.Lite.Web.Api.Setup
{
    public static class CoreAppServices
    {
        public static void AddCoreAppServices(this WebApplicationBuilder builder)
        {
            //builder.Services.AddCustomAutoMapper(typeof(CoreAppApiMarker).Assembly, typeof(CoreAppInfrastructureMarker).Assembly);
            builder.Services.AddAutoMapperConfiguration();

            //var dbConnectionInfo = CoreAppSettings.Instance.GetDbConnectionInfo(builder.Configuration);
            //var connectionString = "Data Source=localhost\\SQL2016;Initial Catalog=ELC.Lite;Integrated Security=SSPI;";
            var connectionString = "Data Source=localhost\\SQL2016;Initial Catalog=ELC.Lite;Integrated Security=true;encrypt=yes;TrustServerCertificate=True;Persist Security Info=False;";

            //< add name = "Dentsu" connectionString = "Data Source=AUDSTAGDB2;Initial Catalog=Dentsu;Integrated Security=true;encrypt=yes;TrustServerCertificate=True;Persist Security Info=False;" providerName = "System.Data.SqlClient" />

            builder.Services.AddDbContext<CoreDbContext>(options =>
            {
                //options.UseSqlServer(dbConnectionInfo.ConnectionString, sqlServerOptions =>
                options.UseSqlServer(connectionString, sqlServerOptions =>
                {
                    //if (dbTimeout is not null)
                    //{
                    //    sqlServerOptions.CommandTimeout(dbTimeout.Value);
                    //}
                    //sqlServerOptions.UseQueryableValues(config =>
                    //{
                    //    config.Serialization(SqlServerSerialization.UseJson);
                    //});
                });
            });

            builder.Services.AddLeadServices();
        }
        private static void AddLeadServices(this IServiceCollection services)
        {
            services.AddScoped<ILeadRepository, LeadRepository>();
            services.AddScoped<ILeadService, LeadService>();
        }
    }
}
