using Heimdall.Assets;
using Heimdall.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Heimdall.Services
{
    public class ServiceResolver<T> where T : class
    {
        private static ServiceProvider serviceProvider;

        private static void Register()
        {
            if (serviceProvider != null)
                return;

            //setup our DI
            serviceProvider = new ServiceCollection()
                .AddTransient<IOrganizationService, OrganizationService>()
                .AddTransient<IUserService, UserService>()
                .BuildServiceProvider();
        }

        public static T Resolve()
        {
            Register();
            return serviceProvider.GetService<T>();
        }
    }
}
