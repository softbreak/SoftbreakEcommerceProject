using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Project.BLL.Services;
using Project.BLL.Services.Interfaces;
using Project.BLL.UnitOfWorks;

namespace Project.BLL.Configurations;

public static class ServiceConfigurationExtension
{
    public static IServiceCollection AddBLLServiceContainer(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork,UnitOfWork>();
        services.AddScoped<IProductService,ProductService>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        
        return services;
    }
}