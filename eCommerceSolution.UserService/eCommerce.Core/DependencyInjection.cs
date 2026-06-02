using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core;

    public static class DependencyInjection
    {
        /// <summary>
        /// Extension method to add core service to the dependency injection container
        /// </summary>
        /// <param name="IServiceCollection"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
        //To Do : Add service to the IoC container 
        //Core service often include data access, caching and other low level components.
        services.AddTransient<IUserService, UserService>();
        return services;
        }
    }


