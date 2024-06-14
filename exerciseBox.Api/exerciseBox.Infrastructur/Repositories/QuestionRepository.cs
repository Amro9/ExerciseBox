using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace exerciseBox.Infrastructur.Repositories
{
    internal class QuestionRepository : IQuestionRepository
    {
        private readonly ExerciseBoxContext _context;

        public QuestionRepository(ExerciseBoxContext context)
        {
            _context = context;
        }

        public  async Task<Questions> Create(Questions entity)
        {
           await _context.Questions.AddAsync(entity);
            int effectedRows =  await _context.SaveChangesAsync();
            if (effectedRows > 0)
            {
                return entity;
            }
            return null;

        }

        public Task<Questions> Delete(Questions entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Questions>> GetAllQuestionsByRangeOfIdsAsync(string[] questionIds)
        {
            return await _context.Questions.Where(q => questionIds.Contains(q.Id.ToString())).ToListAsync();
        }

        public async Task<IEnumerable<Questions>> Read()
        {
            return await _context.Questions.Where(q => q.QuestionIsPrivate == false).ToListAsync();
        }

        public Task<Questions> ReadById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Questions> Update(Questions entity)
        {
            throw new NotImplementedException();
        }
    }
}
