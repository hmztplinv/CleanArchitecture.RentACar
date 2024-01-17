using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;


public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly()); // AutoMapper kütüphanesi kullanılarak nesnelerin birbirine dönüştürülmesi sağlanıyor.
        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules)); // BaseBusinessRules sınıfından türeyen sınıfların hepsi ekleniyor.
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()); // FluentValidation kütüphanesi kullanılarak nesnelerin doğrulanması sağlanıyor.

        services.AddMediatR(configuration => 
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); // MediatR kütüphanesi kullanılarak nesnelerin birbirine bağlanması sağlanıyor.

            configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>)); // RequestValidationBehavior sınıfı kullanılarak nesnelerin doğrulanması sağlanıyor.
            configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>)); // TransactionBehavior sınıfı kullanılarak nesnelerin transaction işlemleri sağlanıyor.
            configuration.AddOpenBehavior(typeof(CachingBehavior<,>));
            configuration.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));
            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>)); // LoggingBehavior sınıfı kullanılarak nesnelerin loglanması sağlanıyor.
        });
        
        services.AddSingleton<LoggerServiceBase,MsSqlLogger>();

        return services;
    }
     public static IServiceCollection AddSubClassesOfType(
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
    ) //
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList(); // type sınıfından türeyen sınıfların listesi alınıyor.
        foreach (Type? item in types) // type sınıfından türeyen sınıfların listesi dönülüyor.
            if (addWithLifeCycle == null) // addWithLifeCycle null ise
                services.AddScoped(item); // AddScoped metodu ile sınıf ekleniyor.
            else
                addWithLifeCycle(services, type); // addWithLifeCycle null değil ise addWithLifeCycle metodu çağrılıyor.
        return services; 
    }
}