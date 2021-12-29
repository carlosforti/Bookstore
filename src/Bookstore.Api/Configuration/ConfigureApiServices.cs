using Bookstore.Infra.Data.Configuration;

namespace Bookstore.Api
{
    public static class ConfigureApiServices
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.ConfigureInfraDataServices();

            return services;
        }
    }
}
