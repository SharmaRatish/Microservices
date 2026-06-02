using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure;

public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add infrastrucure service to the dependency injection container
    /// </summary>
    /// <param name="IServiceCollection"></param>
    /// <param name=""></param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        //To Do : Add service to the IoC container 
        //Infrastructure service often include data access, caching and other low level components.
        services.AddTransient<IUserRepository, UserRepository>();
        return services;
    }
}

