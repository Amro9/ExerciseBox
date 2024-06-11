using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Extensions;

public static class SchoolTypesMappingExtension
{
    public static IEnumerable<SchoolTypeDto> MapToSchoolTypeDtos(this IEnumerable<SchoolTypes> schoolTypes)
    {
        return schoolTypes.Select(schooltype => new SchoolTypeDto
        {
            Id = schooltype.Id,
            Description = schooltype.Name
        });
    }
}
