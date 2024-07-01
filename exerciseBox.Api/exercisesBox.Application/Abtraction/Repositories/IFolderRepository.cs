using exerciseBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace exerciseBox.Application.Abtraction.Repositories
{
    /// <summary>
    /// Stellt Methoden für den Zugriff auf Ordnerdaten bereit.
    /// </summary>
    public interface IFolderRepository : IRepository<Folders, Guid>
    {
        /// <summary>
        /// Ruft eine Auflistung von Ordnern ab, die mit der angegebenen Lehrer-ID verknüpft sind.
        /// </summary>
        /// <param name="id">Die ID des Lehrers.</param>
        /// <returns>Eine Auflistung von <see cref="Folders"/>.</returns>
        Task<IEnumerable<Folders>> GetFoldersByTeacherId(string id);

        /// <summary>
        /// Ruft den Erstellungsordner für das angegebene Fach und den angegebenen Lehrer ab.
        /// </summary>
        /// <param name="subjectId">Die ID des Fachs.</param>
        /// <param name="teacherId">Die ID des Lehrers.</param>
        /// <returns>Der Erstellungsordner als <see cref="Folders"/>.</returns>
        Task<Folders> GetCreationFolder(string subjectId, string teacherId);

        /// <summary>
        /// Ruft eine Auflistung von Ordnern ab, die mit dem angegebenen Fach und Lehrer verknüpft sind.
        /// </summary>
        /// <param name="subjectId">Die ID des Fachs.</param>
        /// <param name="teacherId">Die ID des Lehrers.</param>
        /// <returns>Eine Auflistung von <see cref="Folders"/>.</returns>
        Task<IEnumerable<Folders>> GetSubjectFolders(string subjectId, string teacherId);
    }
}
