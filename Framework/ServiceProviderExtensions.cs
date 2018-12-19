using Microsoft.Extensions.DependencyInjection;
using System;

namespace Framework
{
    public static class ServiceProviderExtensions
    {
        public static void RunStartupActions(this IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                serviceScope.ServiceProvider.GetServices<IHaveStartupActions>().Startup();
            }
        }
    }
}
