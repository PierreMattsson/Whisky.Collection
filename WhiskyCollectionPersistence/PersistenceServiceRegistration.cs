using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Whisky.Collection.Application.Contracts.Persistence;
using WhiskyCollectionPersistence.DatabaseContext;
using WhiskyCollectionPersistence.Repository;

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

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IMyWhiskyRepository, MyWhiskyRepository>();

        return services;
    }
}
