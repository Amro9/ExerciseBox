using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Extensions;

public static class SchoolMappingExtension
{
    public static IEnumerable<SchoolDto> MapToSchoolDto(this IEnumerable<Schools> schools)
    {
        return schools.Select(school => new SchoolDto
        {
            Id = Guid.Parse(school.Id),
            Name = school.Name,
            SchoolType = school.SchoolTypeNavigation
        });
    }

    public static IEnumerable<Schools> MapToDomainSchools(this IEnumerable<SchoolDto> schools)
    {
        return schools.Select(school => new Schools
        {
            Id = school.Id.ToString(),
            Name = school.Name,
            SchoolTypeNavigation = school.SchoolType
        });
    }
}
