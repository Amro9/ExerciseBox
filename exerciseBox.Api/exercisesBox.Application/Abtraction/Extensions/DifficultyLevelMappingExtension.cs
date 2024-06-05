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
                Id = Guid.Parse(difficultyLevel.Id),
                Description = difficultyLevel.Description
            });
        }
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
