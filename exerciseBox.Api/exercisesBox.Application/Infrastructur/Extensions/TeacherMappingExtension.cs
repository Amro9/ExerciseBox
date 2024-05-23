using exerciseBox.Application.Infrastructur.Models;
using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Infrastructur.Extensions;

public static class TeacherMappingExtension
{
    public static IEnumerable<TeacherDto> MapToTeacherDto(this IEnumerable<Teacher> teachers)
    {
        return teachers.Select(teacher => new TeacherDto
        {
            Id = teacher.Id,
            Name = teacher.Name,
            Email = teacher.Email,
            School = teacher.School
        });
    }
    
    public static IEnumerable<Teacher> MapToDomainTeachers(this IEnumerable<TeacherDto> teachers)
    {
        return teachers.Select(teacher => new Teacher
        {
            Id = teacher.Id,
            Name = teacher.Name,
            Email = teacher.Email,
            School = teacher.School
        });
    }
}
