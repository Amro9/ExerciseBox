using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Repositories
{
    /// <summary>
    /// Schnittstelle für das School Repository.
    /// Erbt von IRepository mit Schools als Entitätstyp und String als Schlüsseltyp.
    /// </summary>
    public interface ISchoolRepository : IRepository<Schools, string>
    {
        /// <summary>
        /// Liest asynchron die Schule anhand der gegebenen E-Mail.
        /// </summary>
        /// <param name="email">Die E-Mail, um die Schule zu lesen.</param>
        /// <returns>Eine Aufgabe, die den asynchronen Vorgang darstellt. Das Ergebnis der Aufgabe ist die Schule.</returns>
        Task<Schools> ReadByEmail(string email);
    }
}