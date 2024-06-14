using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace exerciseBox.Application.Abtraction.Extensions
{
    /// <summary>
    /// Erweiterungsmethoden für die Zuordnung von Schultypen zwischen der Domäne (DB) und den DTOs.
    /// </summary>
    public static class SchoolTypesMappingExtension
    {
        /// <summary>
        /// Mappt eine Sammlung von <see cref="SchoolTypes"/> zu einer Sammlung von <see cref="SchoolTypeDto"/>.
        /// </summary>
        /// <param name="schoolTypes">Die Sammlung der <see cref="SchoolTypes"/>.</param>
        /// <returns>Eine Sammlung von <see cref="SchoolTypeDto"/>.</returns>
        public static IEnumerable<SchoolTypeDto> MapToSchoolTypeDtos(this IEnumerable<SchoolTypes> schoolTypes)
        {
            return schoolTypes.Select(schoolType => new SchoolTypeDto
            {
                Id = schoolType.Id,
                Description = schoolType.Name
            });
        }

        /// <summary>
        /// Mappt eine Sammlung von <see cref="SchoolTypeDto"/> zu einer Sammlung von <see cref="SchoolTypes"/>.
        /// </summary>
        /// <param name="schoolTypeDtos">Die Sammlung der <see cref="SchoolTypeDto"/>.</param>
        /// <returns>Eine Sammlung von <see cref="SchoolTypes"/>.</returns>
        public static IEnumerable<SchoolTypes> MapToSchoolTypes(this IEnumerable<SchoolTypeDto> schoolTypeDtos)
        {
            return schoolTypeDtos.Select(schoolTypeDto => new SchoolTypes
            {
                Id = schoolTypeDto.Id,
                Name = schoolTypeDto.Description
            });
        }
    }
}
