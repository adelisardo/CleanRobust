using CleanRobust.Application.Common.Behaviours;
using CleanRobust.Application.Common.Profiles;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanRobust.Application;

public static class ConfigureServices
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(c =>
        {
            c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            c.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        });

        var mapperConfig = new MapperConfiguration(c => c.AddProfile(new MappingProfile()));
        services.AddSingleton(mapperConfig.CreateMapper());

        return services;
    }
}
