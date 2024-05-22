namespace exerciseBox.Application.Infrastructur.Models;

public class Teacher
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public SchoolDto School { get; set; }

    public static implicit operator Teacher(Domain.Entities.Teacher teacher)
    {
        return new Teacher
        {
            Id = teacher.Id,
            Name = teacher.Name,
            Email = teacher.Email,
            PhoneNumber = teacher.PhoneNumber,
            School = teacher.School
        };
    }

    public static implicit operator Domain.Entities.Teacher(Teacher teacher)
    {
        return new Domain.Entities.Teacher
        {
            Id = teacher.Id,
            Name = teacher.Name,
            Email = teacher.Email,
            PhoneNumber = teacher.PhoneNumber,
            School = teacher.School
        };
    }
}
