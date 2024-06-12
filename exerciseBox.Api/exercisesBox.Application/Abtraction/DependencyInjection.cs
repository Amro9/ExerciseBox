using exerciseBox.Application.Services;
using exerciseBox.Application.Services.Interface;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace exerciseBox.Application.Abtraction;

public static class DependencyInjection
{
    public static IServiceCollection AddApplictaionConfiguration(this IServiceCollection services)
    {
        //Add MedaitR
        var assembly = typeof(DependencyInjection).GetTypeInfo().Assembly;
        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));

        services.AddSingleton<ISessionCommunicator, SessionCommunicator>();
        services.AddSingleton<IExerciseSheetGenerator, ExerciseSheetGenerator>();

        return services;
    }
}

