using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WhiskyCollectionPersistence.DatabaseContext;

namespace WhiskyCollectionPersistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddDbContext<MyWhiskyDatabaseContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("MyWhiskyDatabaseConnectionString"));
        });

        return services;
    }
}
