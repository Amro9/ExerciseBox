using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace exerciseBox.Infrastructur.Repositories;

public class TeacherRepository : ITeacherRepository
{
    private readonly ExerciseBoxContext _context;

    public TeacherRepository(ExerciseBoxContext context)
    {
        _context = context;
    }

    public Task<Teachers> Create(Teachers entity)
    {
        throw new NotImplementedException();
    }

    public Task<Teachers> Delete(Teachers entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Teachers>> Read()
    {
        return await _context.Teachers.Include(x => x.SchoolNavigation).ThenInclude(x => x.SchoolTypeNavigation).ToListAsync();
    }

    public Task<Teachers> ReadById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Teachers> Update(Teachers entity)
    {
        throw new NotImplementedException();
    }
}
