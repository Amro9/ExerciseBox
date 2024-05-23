namespace exerciseBox.Application.Infrastructur.Models;

public class TeacherDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public SchoolDto School { get; set; }

    public static implicit operator TeacherDto(Domain.Entities.Teacher teacher)
    {
        return new TeacherDto
        {
            Id = teacher.Id,
            Name = teacher.Name,
            Email = teacher.Email,
            School = teacher.School
        };
    }

    public static implicit operator Domain.Entities.Teacher(TeacherDto teacher)
    {
        return new Domain.Entities.Teacher
        {
            Id = teacher.Id,
            Name = teacher.Name,
            Email = teacher.Email,
            School = teacher.School
        };
    }
}
