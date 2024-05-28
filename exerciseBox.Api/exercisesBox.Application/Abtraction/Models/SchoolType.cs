using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Models;

public class SchoolType
{
    public string Id { get; set; }
    public string Description { get; set; }

    public static implicit operator SchoolType(SchoolTypes schoolType)
    {
        if(schoolType == null)
        {
            return null;
        }
        return new SchoolType
        {
            Id = schoolType.Id,
            Description = schoolType.Name
        };
    }

    public static implicit operator SchoolTypes(SchoolType schoolType)
    {
        return new SchoolTypes
        {
            Id = schoolType.Id,
            Name = schoolType.Description
        };
    }
}
