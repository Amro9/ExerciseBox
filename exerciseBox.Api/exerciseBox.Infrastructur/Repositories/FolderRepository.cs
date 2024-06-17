using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace exerciseBox.Infrastructur.Repositories;

public class FolderRepository : IFolderRepository
{
    private readonly ExercisesBoxContext _context;

    public FolderRepository(ExercisesBoxContext exercisesBoxContext)
    {
        _context = exercisesBoxContext;
    }

    public Task<Folders> Create(Folders entity)
    {
        throw new NotImplementedException();
    }

    public Task<Folders> Delete(Folders entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Folders>> GetFoldersByTeacherId(string id)
    {
        return await _context.Folders.Where(f => f.Teacher == id).ToListAsync();
    }

    public Task<IEnumerable<Folders>> Read()
    {
        throw new NotImplementedException();
    }

    public Task<Folders> ReadById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Folders> Update(Folders entity)
    {
        throw new NotImplementedException();
    }
}
