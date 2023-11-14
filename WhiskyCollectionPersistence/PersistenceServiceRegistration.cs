using Microsoft.Extensions.DependencyInjection;

namespace WhiskyCollectionPersistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        return services;
    }
}
