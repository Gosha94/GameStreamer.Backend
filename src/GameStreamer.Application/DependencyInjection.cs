using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace GameStreamer.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        //var applicationAssembly = typeof(DependencyInjection).Assembly;

        //services.AddMediatR(config =>
        //    config.RegisterServicesFromAssembly(applicationAssembly));

        //services.AddValidatorsFromAssembly(applicationAssembly);

        return services;
    }
}