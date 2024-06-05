using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace exerciseBox.Infrastructur.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        private readonly ExerciseBoxContext _context;

        public TopicRepository(ExerciseBoxContext context)
        {
            _context = context;
        }
        public Task<Topics> Create(Topics entity)
        {
            throw new NotImplementedException();
        }

        public Task<Topics> Delete(Topics entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Topics>> Read()
        {
            return await _context.Topics.ToListAsync();
        }
        public async Task<IEnumerable<Topics>> ReadBySubject(string subject)
        {
            return await _context.Topics.Where(t => t.Subject == subject).Include(s =>s.SubjectNavigation).ToListAsync();
        }
        public Task<Topics> ReadById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Topics> Update(Topics entity)
        {
            throw new NotImplementedException();
        }
    }
}
