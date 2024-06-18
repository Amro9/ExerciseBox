using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace exerciseBox.Infrastructur.Repositories;

public class SchoolRepository : ISchoolRepository
{
    private readonly ExercisesBoxContext _context;

    public SchoolRepository(ExercisesBoxContext context)
    {
        _context = context;
    }

    public async Task<Schools> CreateAsync(Schools entity)
    {
        await _context.Schools.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Schools> DeleteAsync(Schools entity)
    {
        _context.Schools.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<Schools>> ReadAsync()
    {
        return await _context.Schools.Include(x => x.SchoolTypeNavigation).ToListAsync();
    }

    public async Task<Schools> ReadByEmail(string email)
    {
        return await _context.Schools.Include(x => x.SchoolTypeNavigation).FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<Schools> ReadByIdAsync(string id)
    {
        return await _context.Schools.Include(x => x.SchoolTypeNavigation).FirstOrDefaultAsync(x => x.Email == id.ToString());
    }

    public async Task<Schools> UpdateAsync(Schools entity)
    {
        throw new NotImplementedException();
    }
}
