

using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace exerciseBox.Infrastructur.Repositories
{
    internal class QuestionRepository : IQuestionRepository
    {
        private readonly ExerciseBoxContext _context;
        public QuestionRepository(ExerciseBoxContext context) { 
            _context = context;
        }
        public Task<Questions> Create(Questions entity)
        {
            throw new NotImplementedException();
        }

        public Task<Questions> Delete(Questions entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Questions>> Read()
        {
            Console.WriteLine( _context.Questions.ToList().FirstOrDefault().content);
            return await _context.Questions.ToListAsync();
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
