using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Models;

public class SchoolDto
{
    public Guid Id { get; set; }
    public SchoolType SchoolType { get; set; }
    public string Name { get; set; }

    public static implicit operator SchoolDto(Schools school)
    {
        return new SchoolDto
        {
            Id = Guid.Parse(school.Id),
            Name = school.Name,
            SchoolType = school.SchoolTypeNavigation
        };
    }

    public static implicit operator Schools(SchoolDto school)
    {
        return new Schools
        {
            Id = school.Id.ToString(),
            Name = school.Name,
            SchoolTypeNavigation = school.SchoolType
        };
    }
}
