using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Repositories
{
    /// <summary>
    /// Schnittstelle für das School Type Repository.
    /// Erbt von IRepository mit SchoolTypes als Entitätstyp und Guid als Schlüsseltyp.
    /// </summary>
    public interface ISchoolTypeRepository : IRepository<SchoolTypes, Guid>
    {
        Task<int> ReadIdByTeacher(string teacherId);
    }
}
