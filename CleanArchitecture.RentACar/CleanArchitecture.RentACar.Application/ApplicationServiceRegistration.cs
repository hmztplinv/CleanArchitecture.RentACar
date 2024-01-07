using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration => 
        {
            configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
        });
        services.AddScoped<BrandBusinessRules>();

        return services;
    }
}