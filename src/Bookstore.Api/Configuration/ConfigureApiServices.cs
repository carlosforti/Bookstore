using Bookstore.Infra.CrossCutting.Configurations;

namespace Bookstore.Api.Configuration
{
    public static class ConfigureApiServices
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.ConfigureCrossCuttingServices();

            return services;
        }
    }
}
