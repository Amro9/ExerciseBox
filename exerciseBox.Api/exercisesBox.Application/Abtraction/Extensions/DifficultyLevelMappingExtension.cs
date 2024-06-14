using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace exerciseBox.Application.Abtraction.Extensions
{
    /// <summary>
    /// Erweiterungsmethoden für die Zuordnung von Schwierigkeitsgraden zwischen der Domäne (DB) und den DTOs.
    /// </summary>
    public static class DifficultyLevelMappingExtension
    {
        /// <summary>
        /// Mappt eine Sammlung von <see cref="QuestionDifficultyLevels"/> zu einer Sammlung von <see cref="DifficultyLevelDto"/>.
        /// </summary>
        /// <param name="difficultyLevels">Die Sammlung der <see cref="QuestionDifficultyLevels"/>.</param>
        /// <returns>Eine Sammlung von <see cref="DifficultyLevelDto"/>.</returns>
        public static IEnumerable<DifficultyLevelDto> MapToDifficultyLevelDto(this IEnumerable<QuestionDifficultyLevels> difficultyLevels)
        {
            return difficultyLevels.Select(difficultyLevel => new DifficultyLevelDto
            {
                Id = Guid.Parse(difficultyLevel.Id),
                Description = difficultyLevel.Description
            });
        }

        /// <summary>
        /// Mapped eine Sammlung von <see cref="DifficultyLevelDto"/> zu einer Sammlung von <see cref="QuestionDifficultyLevels"/>.
        /// </summary>
        /// <param name="difficultyLevels">Die Sammlung der <see cref="DifficultyLevelDto"/>.</param>
        /// <returns>Eine Sammlung von <see cref="QuestionDifficultyLevels"/>.</returns>
        public static IEnumerable<QuestionDifficultyLevels> MapToDomainDifficultyLevels(this IEnumerable<DifficultyLevelDto> difficultyLevels)
        {
            return difficultyLevels.Select(difficultyLevel => new QuestionDifficultyLevels
            {
                Id = difficultyLevel.Id.ToString(),
                Description = difficultyLevel.Description
            });
        }
    }
}
