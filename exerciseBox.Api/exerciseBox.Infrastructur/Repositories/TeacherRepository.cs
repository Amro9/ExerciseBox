using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Domain.Entities;

namespace exerciseBox.Infrastructur.Repositories;

public class TeacherRepository : ITeacherRepository
{
    public Task<Teachers> Create(Teachers entity)
    {
        throw new NotImplementedException();
    }

    public Task<Teachers> Delete(Teachers entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Teachers>> Read()
    {
        throw new NotImplementedException();
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
