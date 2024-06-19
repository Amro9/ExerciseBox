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

    public Task<Folders> CreateAsync(Folders entity)
    {
        throw new NotImplementedException();
    }

    public Task<Folders> DeleteAsync(Folders entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Folders>> GetFoldersByTeacherId(string id)
    {
        return await _context.Folders.Where(f => f.Teacher == id).ToListAsync();
    }

    public Task<IEnumerable<Folders>> ReadAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Folders> ReadByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Folders> UpdateAsync(Folders entity)
    {
        throw new NotImplementedException();
    }
}
