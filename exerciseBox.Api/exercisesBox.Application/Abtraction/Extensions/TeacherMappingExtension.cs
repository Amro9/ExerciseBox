using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace exerciseBox.Application.Abtraction.Extensions
{
    /// <summary>
    /// Erweiterungsmethoden für die Zuordnung von Lehrern zwischen der Domäne (DB) und den DTOs.
    /// </summary>
    public static class TeacherMappingExtension
    {
        /// <summary>
        /// Mappt eine Sammlung von <see cref="Teachers"/> zu einer Sammlung von <see cref="TeacherDto"/>.
        /// </summary>
        /// <param name="teachers">Die Sammlung der <see cref="Teachers"/>.</param>
        /// <returns>Eine Sammlung von <see cref="TeacherDto"/>.</returns>
        public static IEnumerable<TeacherDto> MapToTeacherDto(this IEnumerable<Teachers> teachers)
        {
            return teachers.Select(teacher => new TeacherDto
            {
                Surname = teacher.Surname,
                Email = teacher.Email,
                School = teacher.SchoolNavigation
            });
        }

        /// <summary>
        /// Mappt eine Sammlung von <see cref="TeacherDto"/> zu einer Sammlung von <see cref="Teachers"/>.
        /// </summary>
        /// <param name="teachers">Die Sammlung der <see cref="TeacherDto"/>.</param>
        /// <returns>Eine Sammlung von <see cref="Teachers"/>.</returns>
        public static IEnumerable<Teachers> MapToDomainTeachers(this IEnumerable<TeacherDto> teachers)
        {
            return teachers.Select(teacher => (Teachers)teacher);
        }
    }
}
