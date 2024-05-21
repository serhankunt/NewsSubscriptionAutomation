using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NewsSubscriptionAutomation.Domain.Models;

namespace NewsSubscriptionAutomation.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblies(
                typeof(DependencyInjection).Assembly,
                typeof(AppUser).Assembly);
           
        });

        return services;
    }
}

