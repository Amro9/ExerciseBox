using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Infrastructur.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace exerciseBox.Infrastructur;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureConfiguration(this IServiceCollection services)
    {
        services.AddDbContext<ExerciseBoxContext>(options =>
        {
            options.UseSqlServer("name=ConnectionStrings:DefaultConnection");
        });

        services.AddScoped<ISchoolRepository, SchoolRepository>();
        services.AddScoped<ITeacherRepository, TeacherRepository>();

        return services;
    }

}
