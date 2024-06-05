using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Extensions;

public static class TeacherMappingExtension
{
    public static IEnumerable<TeacherDto> MapToTeacherDto(this IEnumerable<Teachers> teachers)
    {
        return teachers.Select(teacher => new TeacherDto
        {
            Surname = teacher.Surname,
            Email = teacher.Email,
            School = teacher.SchoolNavigation
        });
    }
    
    public static IEnumerable<Teachers> MapToDomainTeachers(this IEnumerable<TeacherDto> teachers)
    {
        return teachers.Select(teacher => new Teachers
        {
            Surname = teacher.Surname,
            Email = teacher.Email,
            SchoolNavigation = teacher.School
        });
    }
}
