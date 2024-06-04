

using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace exerciseBox.Infrastructur.Repositories
{
    internal class SubjectRepository : ISubjectRepository
    {
        private readonly ExerciseBoxContext _context;

        public SubjectRepository(ExerciseBoxContext context)
        {
            _context = context;
        }
        public Task<Subjects> Create(Subjects entity)
        {
            throw new NotImplementedException();
        }
        public Task<Subjects> Delete(Subjects entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Subjects>> Read()
        {
            return await _context.Subjects.ToListAsync();   
        }

        public Task<Subjects> ReadById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Subjects> Update(Subjects entity)
        {
            throw new NotImplementedException();
        }
    }
}
