using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace exerciseBox.Infrastructur.Repositories
{
    internal class QuestionRepository : IQuestionRepository
    {
        private readonly ExercisesBoxContext _context;

        public QuestionRepository(ExercisesBoxContext context)
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

        public async Task<IEnumerable<Questions>> GetFolderQuestions(string folderid)
        {
            var questions =  await _context.FoldersQuestionsJunction.Where(fq => fq.Folder == folderid).Select(fq => fq.QuestionNavigation).ToListAsync();
            foreach (var question in questions)
            {
                question.TopicNavigation = await _context.Topics.FindAsync(question.Topic);
            }
            return questions;
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
