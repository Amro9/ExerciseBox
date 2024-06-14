using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Repositories
{
    /// <summary>
    /// Schnittstelle für das Teacher Repository.
    /// Erbt von IRepository mit Teachers als Entitätstyp und String als Schlüsseltyp.
    /// </summary>
    public interface ITeacherRepository : IRepository<Teachers, string>
    {
        /// <summary>
        /// Liest asynchron den Lehrer anhand der gegebenen E-Mail.
        /// </summary>
        /// <param name="email">Die E-Mail, um den Lehrer zu lesen.</param>
        /// <returns>Eine Aufgabe, die den asynchronen Vorgang darstellt. Das Ergebnis der Aufgabe ist der Lehrer.</returns>
        Task<Teachers> ReadByEmailAsync(string email);

        /// <summary>
        /// Liest asynchron die Lehrer anhand der gegebenen Schul-ID.
        /// </summary>
        /// <param name="schoolId">Die ID der Schule, um die Lehrer zu lesen.</param>
        /// <returns>Eine Aufgabe, die den asynchronen Vorgang darstellt. Das Ergebnis der Aufgabe ist eine Auflistung von Lehrern.</returns>
        Task<IEnumerable<Teachers>> ReadBySchoolIdAsync(string schoolId);
    }
}
