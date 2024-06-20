

using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace exerciseBox.Infrastructur.Repositories
{
    internal class SubjectRepository : ISubjectRepository
    {
        private readonly ExercisesBoxContext _context;

        public SubjectRepository(ExercisesBoxContext context)
        {
            _context = context;
        }
        public Task<Subjects> CreateAsync(Subjects entity)
        {
            throw new NotImplementedException();
        }
        public Task<Subjects> DeleteAsync(Subjects entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Subjects>> GetSubjectsByTeacherId(string id)
        {
            var subjectIds = await _context.TeachersSubjectsJunction.Where(x => x.Teacher == id).Select(x => x.Subject).ToListAsync();
            return await _context.Subjects.Where(x => subjectIds.Contains(x.Id)).ToListAsync();
        }

        public async Task<IEnumerable<Subjects>> ReadAsync()
        {
            return await _context.Subjects.ToListAsync();   
        }

        public Task<Subjects> ReadByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Subjects> UpdateAsync(Subjects entity)
        {
            throw new NotImplementedException();
        }
    }
}
