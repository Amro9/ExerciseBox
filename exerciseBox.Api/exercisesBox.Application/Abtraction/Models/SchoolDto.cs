using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Models;

public class SchoolDto
{
    public SchoolType SchoolType { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }

    public static implicit operator SchoolDto(Schools school)
    {
        if(school is null)
            return null;

        return new SchoolDto
        {
            Name = school.Name,
            SchoolType = school.SchoolTypeNavigation
        };
    }

    public static implicit operator Schools(SchoolDto school)
    {
        if (school is null)
            return null;

        return new Schools
        {
            Name = school.Name,
            SchoolTypeNavigation = school.SchoolType
        };
    }
}
