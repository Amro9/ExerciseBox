

using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace exerciseBox.Infrastructur.Repositories
{
    internal class DifficultyLevelRepository : IDifficultyLevelRepository
    {
        private readonly ExercisesBoxContext _context;

        public DifficultyLevelRepository(ExercisesBoxContext context)
        {
            _context = context;
        }

        public Task<QuestionDifficultyLevels> CreateAsync(QuestionDifficultyLevels entity)
        {
            throw new NotImplementedException();
        }

        public Task<QuestionDifficultyLevels> DeleteAsync(QuestionDifficultyLevels entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<QuestionDifficultyLevels>> ReadAsync()
        {
            return await _context.QuestionDifficultyLevels.ToListAsync();
        }

        public Task<QuestionDifficultyLevels> ReadByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<QuestionDifficultyLevels> UpdateAsync(QuestionDifficultyLevels entity)
        {
            throw new NotImplementedException();
        }
    }
}
