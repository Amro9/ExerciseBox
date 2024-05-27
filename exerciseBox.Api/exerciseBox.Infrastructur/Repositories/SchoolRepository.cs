using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Domain.Entities;

namespace exerciseBox.Infrastructur.Repositories;

public class SchoolRepository : ISchoolRepository
{
    private readonly ExerciseBoxContext _context;

    public SchoolRepository(ExerciseBoxContext context)
    {
        _context = context;
    }

    public async Task<Schools> Create(Schools entity)
    {
        await _context.Schools.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Schools> Delete(Schools entity)
    {
        _context.Schools.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<Schools>> Read()
    {
        throw new NotImplementedException();
    }

    public async Task<Schools> ReadById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Schools> Update(Schools entity)
    {
        throw new NotImplementedException();
    }
}
