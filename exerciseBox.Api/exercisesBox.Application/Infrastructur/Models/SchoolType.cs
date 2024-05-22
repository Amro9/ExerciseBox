namespace exerciseBox.Application.Infrastructur.Models;

public class SchoolType
{
    public Guid Id { get; set; }
    public string Description { get; set; }

    public static implicit operator SchoolType(Domain.Entities.SchoolType schoolType)
    {
        return new SchoolType
        {
            Id = schoolType.Id,
            Description = schoolType.Description
        };
    }

    public static implicit operator Domain.Entities.SchoolType(SchoolType schoolType)
    {
        return new Domain.Entities.SchoolType
        {
            Id = schoolType.Id,
            Description = schoolType.Description
        };
    }
}
