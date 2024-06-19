using exerciseBox.Domain.Entities;

/// <summary>
/// Namensraum für die Abstraktion von Repositories.
/// </summary>
namespace exerciseBox.Application.Abtraction.Repositories
{
    /// <summary>
    /// Schnittstelle für das School Level Repository.
    /// Erbt von IRepository mit Integer-Typen für Schlüssel und Wert.
    /// </summary>
    public interface ISchoolLevelRepository : IRepository<int, int>
    {
        /// <summary>
        /// Liest asynchron die Schulstufen anhand der gegebenen Lehrer-ID.
        /// </summary>
        /// <param name="teacherId">Die ID des Lehrers.</param>
        /// <returns>Eine Aufgabe, die den asynchronen Vorgang darstellt. Das Ergebnis der Aufgabe enthält eine aufzählbare Sammlung von Ganzzahlen, die die Schulstufen darstellen.</returns>
        Task<IEnumerable<int>> ReadByTeacherId(string teacherId);

        Task<IEnumerable<int>> ReadBySchoolTypeId(int schoolTypeId);
    }
}
