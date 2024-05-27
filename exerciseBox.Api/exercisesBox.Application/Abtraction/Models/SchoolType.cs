using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Models;

public class SchoolType
{
    public Guid Id { get; set; }
    public string Description { get; set; }

    public static implicit operator SchoolType(SchoolTypes schoolType)
    {
        return new SchoolType
        {
            Id = Guid.Parse(schoolType.Id),
            Description = schoolType.Name
        };
    }

    public static implicit operator SchoolTypes(SchoolType schoolType)
    {
        return new SchoolTypes
        {
            Id = schoolType.Id.ToString(),
            Name = schoolType.Description
        };
    }
}
