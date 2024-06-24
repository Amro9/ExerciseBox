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

        public  async Task<Questions> CreateAsync(Questions entity)
        {
           await _context.Questions.AddAsync(entity);
            int effectedRows =  await _context.SaveChangesAsync();
            if (effectedRows > 0)
            {
                return entity;
            }
            return null;

        }

        public Task<Questions> DeleteAsync(Questions entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Questions>> GetAllQuestionsByRangeOfIdsAsync(string[] questionIds)
        {
            return await _context.Questions.Where(q => questionIds.Contains(q.Id.ToString())).ToListAsync();
        }

        public async Task<IEnumerable<Questions>> GetFolderQuestions(string folderid)
        {
            var questions = await _context.FoldersQuestionsJunction.Where(fq => fq.Folder == folderid).Select(fq => fq.QuestionNavigation).ToListAsync();
            return await _context.Questions.Where(q => questions.Contains(q)).Include(q=> q.TopicNavigation).ToListAsync();
        }

        public async Task<IEnumerable<Questions>> ReadAsync()
        {
            return await _context.Questions.Where(q => q.QuestionIsPrivate == false).ToListAsync();
        }
        public async Task<IEnumerable<Questions>> GetQuestionsBySubject(string subject)
        {
            var questions =  await _context.Questions
                .Join(
                _context.Topics,
                q => q.Topic,
                t => t.Id,
                (q, t) => new { Question = q, Topic = t })
                .Join(
                _context.Subjects,
                qt => qt.Topic.Subject,
                s => s.Id,
                (qt, s) => new { qt.Question, qt.Topic, subject = s }
                ).Where(qts => qts.subject.Id == subject).
                Select(qts => qts.Question).ToListAsync();

            foreach (var question in questions)
            {
                Console.WriteLine(question.Id);
                Console.WriteLine(question.QuestionText);
            }
            return questions;
        }


        public Task<Questions> ReadByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Questions> UpdateAsync(Questions entity)
        {
            throw new NotImplementedException();
        }
    }
}
