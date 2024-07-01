using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Extensions
{
    /// <summary>
    /// Erweiterungsmethoden für die Zuordnung von Fächern zwischen der Domäne (DB) und den DTOs.
    /// </summary>
    public static class SubjectMappingExtention
    {
        /// <summary>
        /// Mappt eine Sammlung von <see cref="Subjects"/> zu einer Sammlung von <see cref="SubjectDto"/>.
        /// </summary>
        /// <param name="subjects">Die Sammlung der <see cref="Subjects"/>.</param>
        /// <returns>Eine Sammlung von <see cref="SubjectDto"/>.</returns>
        public static IEnumerable<SubjectDto> MapToSubjectDto(this IEnumerable<Subjects> subjects)
        {
            return subjects.Select(s => (SubjectDto)s);
        }

        /// <summary>
        /// Mappt eine Sammlung von <see cref="SubjectDto"/> zu einer Sammlung von <see cref="Subjects"/>.
        /// </summary>
        /// <param name="subjects">Die Sammlung der <see cref="SubjectDto"/>.</param>
        /// <returns>Eine Sammlung von <see cref="Subjects"/>.</returns>
        public static IEnumerable<Subjects> MapToDomainSubjects(this IEnumerable<SubjectDto> subjects)
        {
            return subjects.Select(s => (Subjects)s);
        }
    }
}
