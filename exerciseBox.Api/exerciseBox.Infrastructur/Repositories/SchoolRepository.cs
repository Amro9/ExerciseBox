using exerciseBox.Application.Infrastructur.Models;
using exerciseBox.Application.Infrastruktur.Repositories;
using exerciseBox.Domain.Entities;
using exerciseBox.Infrastructur.Models;

namespace exerciseBox.Infrastructur.Repositories;

public class SchoolRepository : ISchoolRepository
{
    private readonly exercisesBoxContext _context;
   
    public SchoolRepository(exercisesBoxContext context)
    {
        _context = context;
    }

    public Task<School> Create(School entity)
    {
        throw new NotImplementedException();
    }

    public Task<School> Delete(School entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<School>> Read()
    {
        throw new NotImplementedException();
    }

    public Task<School> ReadById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<School> Update(School entity)
    {
        throw new NotImplementedException();
    }
}
