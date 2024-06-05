using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Models;

public class TeacherDto
{
    public string Surname { get; set; }
    public string Givenname { get; set; }
    public string Email { get; set; }
    public SchoolDto School { get; set; }

    public static implicit operator TeacherDto(Teachers teacher)
    {
        return new TeacherDto
        {
            Surname = teacher.Surname,
            Givenname = teacher.FamilyName,
            Email = teacher.Email,
            School = teacher.SchoolNavigation
        };
    }

    public static implicit operator Teachers(TeacherDto teacher)
    {
        return new Teachers
        {
            Surname = teacher.Surname,
            Email = teacher.Email,
            SchoolNavigation = teacher.School
        };
    }
}
