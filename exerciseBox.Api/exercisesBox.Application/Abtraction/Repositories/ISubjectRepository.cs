using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Repositories
{
    /// <summary>
    /// Schnittstelle für das Subject Repository.
    /// Erbt von IRepository mit Subjects als Entitätstyp und Guid als Schlüsseltyp.
    /// </summary>
    public interface ISubjectRepository : IRepository<Subjects, Guid>
    {
        Task<IEnumerable<Subjects>> GetSubjectsByTeacherId(string id);
    }
}
