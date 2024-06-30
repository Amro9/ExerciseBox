using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Domain.Entities;
using exerciseBox.Infrastructur.Repositories;
using exerciseBox.Infrastructure;
using exerciseBox.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace exerciseBox.Infrastructur
{
    /// <summary>
    /// Stellt Erweiterungsmethoden für die Konfiguration der Abhängigkeitsinjektion in der Infrastruktur bereit.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Fügt die erforderlichen Dienste für die Infrastrukturkonfiguration hinzu.
        /// </summary>
        /// <param name="services">Die IServiceCollection, in die die Dienste eingefügt werden sollen.</param>
        /// <returns>Die aktualisierte IServiceCollection.</returns>
        public static IServiceCollection AddInfrastructureConfiguration(this IServiceCollection services)
        {
            // Konfiguration der DbContext für ExercisesBoxContext mit SQL Server
            services.AddDbContext<ExercisesBoxContext>(options =>
            {
                options.UseSqlServer("name=ConnectionStrings:DefaultConnection");
            });

            // Registrierung der Repositories
            services.AddScoped<ISchoolRepository, SchoolRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<ISchoolLevelRepository, SchoolLevelRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<ITopicRepository, TopicRepository>();
            services.AddScoped<IDifficultyLevelRepository, DifficultyLevelRepository>();
            services.AddScoped<ISchoolTypeRepository, SchoolTypeRepository>();
            services.AddScoped<ISchoolBranchesRepository, SchoolBranchesRepository>();
            services.AddScoped<IFolderRepository, FolderRepository>();

            return services;
        }
    }
}
