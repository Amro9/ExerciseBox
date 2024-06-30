using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Repositories
{
    /// <summary>
    /// Schnittstelle für das School Branches Repository.
    /// Erbt von IRepository mit SchoolBranches als Entitätstyp und Integer als Schlüsseltyp.
    /// </summary>
    public interface ISchoolBranchesRepository : IRepository<SchoolBranches, int>
    {
        Task<string> ReadIdByTeacher(string teacherId);
        Task<IEnumerable<SchoolBranches>> ReadBySchoolId(string schoolId);
    }
}
