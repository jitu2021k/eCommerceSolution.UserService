using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure;
public static class DependencyInjection
{
    /// <summary>
    /// Extension Method to add infrastructure services to the dependency Injection container
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // To Do : Add services to the IOC container
        services.AddTransient<IUsersRepositotry, UsersRepository>();
        return services;
    }
}