using ELC.Lite.Web.Api.Leads;

namespace ELC.Lite.Web.Api.Setup
{
    public static class WebApiServices
    {
        public static void AddWebApiServices(this WebApplicationBuilder builder)
        {
            AddCoreAppModuleProxies(builder.Services);
        }

        private static void AddCoreAppModuleProxies(IServiceCollection services)
        {
            services.AddScoped<ILeadProxy, LeadProxy>();
        }
    }
}
