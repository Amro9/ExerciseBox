using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Repositories
{
    /// <summary>
    /// Schnittstelle für das Repository der Schulzweige.
    /// Erbt von IRepository mit SchoolBranches als Entitätstyp und Integer als Schlüsseltyp.
    /// </summary>
    public interface ISchoolBranchesRepository : IRepository<SchoolBranches, int>
    {
        /// <summary>
        /// Liest die ID des Schulzweigs basierend auf der Lehrer-ID.
        /// </summary>
        /// <param name="teacherId">Die ID des Lehrers.</param>
        /// <returns>Die ID des Schulzweigs als Zeichenkette.</returns>
        Task<string> ReadIdByTeacher(string teacherId);

        /// <summary>
        /// Liest alle Schulzweige basierend auf der Schul-ID.
        /// </summary>
        /// <param name="schoolId">Die ID der Schule.</param>
        /// <returns>Eine Auflistung von Schulzweigen.</returns>
        Task<IEnumerable<SchoolBranches>> ReadBySchoolId(string schoolId);
    }
}
