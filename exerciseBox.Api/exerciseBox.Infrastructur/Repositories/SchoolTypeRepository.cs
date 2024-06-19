using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace exerciseBox.Infrastructur.Repositories;

public class SchoolTypeRepository : ISchoolTypeRepository
{
    private readonly ExercisesBoxContext _context;

    public SchoolTypeRepository(ExercisesBoxContext context)
    {
        _context = context;
    }

    public Task<SchoolTypes> CreateAsync(SchoolTypes entity)
    {
        throw new NotImplementedException();
    }

    public Task<SchoolTypes> DeleteAsync(SchoolTypes entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<SchoolTypes>> ReadAsync()
    {
           return  await _context.SchoolTypes.ToListAsync(); 
    }

    public Task<SchoolTypes> ReadByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<SchoolTypes> UpdateAsync(SchoolTypes entity)
    {
        throw new NotImplementedException();
    }
}
