using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace exerciseBox.Application.Abtraction.Extensions
{
    /// <summary>
    /// Erweiterungsmethoden für die Zuordnung von Schulen zwischen der Domäne (DB) und den DTOs.
    /// </summary>
    public static class SchoolMappingExtension
    {
        /// <summary>
        /// Mappt eine Sammlung von <see cref="Schools"/> zu einer Sammlung von <see cref="SchoolDto"/>.
        /// </summary>
        /// <param name="schools">Die Sammlung der <see cref="Schools"/>.</param>
        /// <returns>Eine Sammlung von <see cref="SchoolDto"/>.</returns>
        public static IEnumerable<SchoolDto> MapToSchoolDto(this IEnumerable<Schools> schools)
        {
            return schools.Select(school => new SchoolDto
            {
                Email = school.Email,
                Name = school.Name,
                SchoolType = school.SchoolTypeNavigation
            });
        }

        /// <summary>
        /// Mappt eine Sammlung von <see cref="SchoolDto"/> zu einer Sammlung von <see cref="Schools"/>.
        /// </summary>
        /// <param name="schools">Die Sammlung der <see cref="SchoolDto"/>.</param>
        /// <returns>Eine Sammlung von <see cref="Schools"/>.</returns>
        public static IEnumerable<Schools> MapToDomainSchools(this IEnumerable<SchoolDto> schools)
        {
            return schools.Select(school => new Schools
            {
                Name = school.Name,
                Email = school.Email,
                SchoolTypeNavigation = school.SchoolType
            });
        }
    }
}
