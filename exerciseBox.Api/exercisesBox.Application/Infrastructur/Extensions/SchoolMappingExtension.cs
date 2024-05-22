using exerciseBox.Application.Infrastructur.Models;

namespace exerciseBox.Application.Infrastructur.Extensions;

public static class SchoolMappingExtension
{
    public static IEnumerable<SchoolDto> MapToSchools(this IEnumerable<Domain.Entities.School> schools)
    {
        return schools.Select(school => new SchoolDto
        {
            Id = school.Id,
            Name = school.Name,
            SchoolType = school.Type
        });
    }

    public static IEnumerable<Domain.Entities.School> MapToDomainSchools(this IEnumerable<SchoolDto> schools)
    {
        return schools.Select(school => new Domain.Entities.School
        {
            Id = school.Id,
            Name = school.Name,
            Type = school.SchoolType
        });
    }
}
