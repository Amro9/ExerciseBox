using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Extensions
{
    /// <summary>
    /// Erweiterungsmethoden für die Zuordnung von Schulzweigen zwischen der Domäne (DB) und den DTOs.
    /// </summary>
    public static class SchoolBranchesMappingExtension
    {
        /// <summary>
        /// Mappt eine Sammlung von <see cref="SchoolBranches"/> zu einer Sammlung von <see cref="SchoolBrancheDto"/>.
        /// </summary>
        /// <param name="schoolBranches">Die Sammlung der <see cref="SchoolBranches"/>.</param>
        /// <returns>Eine Sammlung von <see cref="SchoolBrancheDto"/>.</returns>
        public static IEnumerable<SchoolBrancheDto> MapToDto(IEnumerable<SchoolBranches> schoolBranches)
        {
            return schoolBranches.Select(schoolBranch => (SchoolBrancheDto)schoolBranch);
        }

        /// <summary>
        /// Mappt eine Sammlung von <see cref="SchoolBrancheDto"/> zu einer Sammlung von <see cref="SchoolBranches"/>.
        /// </summary>
        /// <param name="schoolBranches">Die Sammlung der <see cref="SchoolBrancheDto"/>.</param>
        /// <returns>Eine Sammlung von <see cref="SchoolBranches"/>.</returns>
        public static IEnumerable<SchoolBranches> MapToEntity(IEnumerable<SchoolBrancheDto> schoolBranches)
        {
            return schoolBranches.Select(schoolBranch => (SchoolBranches)schoolBranch);
        }
    }
}
