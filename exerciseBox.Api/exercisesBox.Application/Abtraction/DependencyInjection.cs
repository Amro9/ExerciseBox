using exerciseBox.Application.Services;
using exerciseBox.Application.Services.Interface;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace exerciseBox.Application.Abtraction
{
    /// <summary>
    /// Statische Klasse zur Konfiguration der Anwendungsdienste.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Fügt die Anwendungskonfiguration zu den Diensten hinzu.
        /// </summary>
        /// <param name="services">Die Sammlung der Dienste.</param>
        /// <returns>Die aktualisierte Sammlung der Dienste.</returns>
        public static IServiceCollection AddApplictaionConfiguration(this IServiceCollection services)
        {
            // MediatR hinzufügen
            var assembly = typeof(DependencyInjection).GetTypeInfo().Assembly;
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));

            // Singleton-Dienste hinzufügen
            services.AddSingleton<ISessionCommunicator, SessionCommunicator>();
            services.AddSingleton<IExerciseSheetGenerator, ExerciseSheetGenerator>();

            return services;
        }
    }
}
