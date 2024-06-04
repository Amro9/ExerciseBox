using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Extensions
{
    public static class DifficultyLevelMappingExtension
    {
        public static IEnumerable<DifficultyLevelDto> MapToDifficultyLevelDto(this IEnumerable<QuestionDifficultyLevels> difficultyLevels)
        {
            return difficultyLevels.Select(difficultyLevel => new DifficultyLevelDto
            {
                Id = Guid.Parse(difficultyLevel.id),
                Description = difficultyLevel.description
            });
        }
        public static IEnumerable<QuestionDifficultyLevels> MapToDomainDifficultyLevels(this IEnumerable<DifficultyLevelDto> difficultyLevels)
        {
            return difficultyLevels.Select(difficultyLevel => new QuestionDifficultyLevels
            {
                id = difficultyLevel.Id.ToString(),
                description = difficultyLevel.Description
            });
        }
    }
}
