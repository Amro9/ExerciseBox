namespace exerciseBox.Application.Abtraction.Repositories
{
    /// <summary>
    /// Definiert eine generische Schnittstelle für ein Repository.
    /// </summary>
    /// <typeparam name="T">Der Typ der Entitäten, die von diesem Repository verwaltet werden.</typeparam>
    /// <typeparam name="A">Der Typ der ID, die von den Entitäten in diesem Repository verwendet wird.</typeparam>
    public interface IRepository<T, A>
    {
        /// <summary>
        /// Liest alle Entitäten.
        /// </summary>
        /// <returns>Eine Aufgabe, die eine Auflistung aller Entitäten darstellt.</returns>
        Task<IEnumerable<T>> Read();

        /// <summary>
        /// Liest eine Entität anhand ihrer ID.
        /// </summary>
        /// <param name="id">Die ID der zu lesenden Entität.</param>
        /// <returns>Eine Aufgabe, die die gelesene Entität darstellt.</returns>
        Task<T> ReadById(A id);

        /// <summary>
        /// Erstellt eine neue Entität.
        /// </summary>
        /// <param name="entity">Die zu erstellende Entität.</param>
        /// <returns>Eine Aufgabe, die die erstellte Entität darstellt.</returns>
        Task<T> Create(T entity);

        /// <summary>
        /// Aktualisiert eine bestehende Entität.
        /// </summary>
        /// <param name="entity">Die zu aktualisierende Entität.</param>
        /// <returns>Eine Aufgabe, die die aktualisierte Entität darstellt.</returns>
        Task<T> Update(T entity);

        /// <summary>
        /// Löscht eine bestehende Entität.
        /// </summary>
        /// <param name="entity">Die zu löschende Entität.</param>
        /// <returns>Eine Aufgabe, die die gelöschte Entität darstellt.</returns>
        Task<T> Delete(T entity);
    }
}
