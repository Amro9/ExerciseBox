using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Repositories
{
    public interface IFolderRepository : IRepository<Folders, Guid>
    {
        Task<IEnumerable<Folders>> GetFoldersByTeacherId(string id);
        Task<Folders> GetCreationFolder(string subjectId, string teacherId);
    }
}
