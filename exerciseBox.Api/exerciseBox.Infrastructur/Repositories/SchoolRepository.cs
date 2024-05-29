using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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
        return await _context.Schools.Include(x => x.SchoolTypeNavigation).ToListAsync();
    }

    public async Task<Schools> ReadByEmail(string email)
    {
        return await _context.Schools.Include(x => x.SchoolTypeNavigation).FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<Schools> ReadById(Guid id)
    {
        return await _context.Schools.Include(x => x.SchoolTypeNavigation).FirstOrDefaultAsync(x => x.Id == id.ToString());
    }

    public async Task<Schools> Update(Schools entity)
    {
        throw new NotImplementedException();
    }
}
