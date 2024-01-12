using AutoMapper;
using ELC.Lite.CoreApp.Api.Leads;

namespace ELC.Lite.Web.Api.Setup.Extensions.Automapper
{
    public static class Configuration
    {
        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
        {
            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new LeadProfile());
                mc.AddProfile(new LeadReverseProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
