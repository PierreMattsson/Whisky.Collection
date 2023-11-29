using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Whisky.Collection.Application.Contracts.Email;
using Whisky.Collection.Application.Contracts.Logging;
using Whisky.Collection.Application.Models.Email;
using Whisky.Collection.Infrastructure.EmailService;
using Whisky.Collection.Infrastructure.Logging;

namespace Whisky.Collection.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
        services.AddTransient<IEmailSender, EmailSender>();
        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

        return services;
    }
}
