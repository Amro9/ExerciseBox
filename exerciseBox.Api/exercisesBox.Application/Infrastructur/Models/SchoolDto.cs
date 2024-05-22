namespace exerciseBox.Application.Infrastructur.Models;

public class SchoolDto
{
    public Guid Id { get; set; }
    public SchoolType SchoolType { get; set; }
    public string Name { get; set; }

    public static implicit operator SchoolDto(exerciseBox.Domain.Entities.School school)
    {
        return new SchoolDto
        {
            Id = school.Id,
            Name = school.Name,
            SchoolType = school.Type
        };
    }

    public static implicit operator exerciseBox.Domain.Entities.School(SchoolDto school)
    {
        return new exerciseBox.Domain.Entities.School
        {
            Id = school.Id,
            Name = school.Name,
            Type = school.SchoolType
        };
    }
}
