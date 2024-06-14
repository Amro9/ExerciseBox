

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

        public Task<QuestionDifficultyLevels> Create(QuestionDifficultyLevels entity)
        {
            throw new NotImplementedException();
        }

        public Task<QuestionDifficultyLevels> Delete(QuestionDifficultyLevels entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<QuestionDifficultyLevels>> Read()
        {
            return await _context.QuestionDifficultyLevels.ToListAsync();
        }

        public Task<QuestionDifficultyLevels> ReadById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<QuestionDifficultyLevels> Update(QuestionDifficultyLevels entity)
        {
            throw new NotImplementedException();
        }
    }
}
