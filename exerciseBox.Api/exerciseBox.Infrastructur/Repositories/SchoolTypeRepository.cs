using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace exerciseBox.Infrastructur.Repositories;

public class SchoolTypeRepository : ISchoolTypeRepository
{
    private readonly ExerciseBoxContext _context;

    public SchoolTypeRepository(ExerciseBoxContext context)
    {
        _context = context;
    }

    public Task<SchoolTypes> Create(SchoolTypes entity)
    {
        throw new NotImplementedException();
    }

    public Task<SchoolTypes> Delete(SchoolTypes entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<SchoolTypes>> Read()
    {
        return await _context.SchoolTypes.ToListAsync();
    }

    public Task<SchoolTypes> ReadById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<SchoolTypes> Update(SchoolTypes entity)
    {
        throw new NotImplementedException();
    }
}
