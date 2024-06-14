using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Models;

public class SchoolTypeDto
{
    public int Id { get; set; }
    public string Description { get; set; }

    public static implicit operator SchoolTypeDto(SchoolTypes schoolType)
    {
        if(schoolType == null)
        {
            return null;
        }
        return new SchoolTypeDto
        {
            Id = schoolType.Id,
            Description = schoolType.Name
        };
    }

    public static implicit operator SchoolTypes(SchoolTypeDto schoolType)
    {
        return new SchoolTypes
        {
            Id = schoolType.Id,
            Name = schoolType.Description
        };
    }
}
