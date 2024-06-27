using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Repositories
{
    /// <summary>
    /// Schnittstelle für das Topic Repository.
    /// Erbt von IRepository mit Topics als Entitätstyp und Guid als Schlüsseltyp.
    /// </summary>
    public interface ITopicRepository : IRepository<Topics, string>
    {
        /// <summary>
        /// Liest asynchron die Themen anhand des gegebenen Fachs.
        /// </summary>
        /// <param name="subject">Das Fach, um die Themen zu lesen.</param>
        /// <returns>Eine Aufgabe, die den asynchronen Vorgang darstellt. Das Ergebnis der Aufgabe ist eine Auflistung von Themen.</returns>
        Task<IEnumerable<Topics>> ReadBySubject(string subject);
    }
}
