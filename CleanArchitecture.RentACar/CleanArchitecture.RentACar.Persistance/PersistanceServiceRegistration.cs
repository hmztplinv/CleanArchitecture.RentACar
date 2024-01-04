using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class PersistanceServiceRegistration
{
    public static IServiceCollection AddPersistanceServices(this IServiceCollection services,  IConfiguration configuration)
    {
        // InMemoryDatabase kullanmak için
        // services.AddDbContext<BaseDbContext>(options =>
        // {
        //     options.UseInMemoryDatabase("RentACarDb");
        // });
        services.AddDbContext<BaseDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("RentACarConnection"));
        });
        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<IModelRepository, ModelRepository>();
        return services;
    }
}