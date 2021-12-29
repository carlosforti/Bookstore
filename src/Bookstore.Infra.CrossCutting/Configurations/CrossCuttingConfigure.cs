using Bookstore.Infra.CrossCutting.Notifications;

using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.Infra.CrossCutting.Configurations
{
    public static class CrossCuttingConfigure
    {
        public static IServiceCollection ConfigureCrossCuttingServices(this IServiceCollection services)
        {
            services.AddSingleton<INotificationContext, NotificationContext>();

            return services;
        }
    }
}
