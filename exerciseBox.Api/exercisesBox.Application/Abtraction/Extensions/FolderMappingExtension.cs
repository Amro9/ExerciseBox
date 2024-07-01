using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Extensions
{
    /// <summary>
    /// Stellt Erweiterungsmethoden für die Zuordnung von Ordnern und Ordner-Datenübertragungsobjekten bereit.
    /// </summary>
    public static class FolderMappingExtension
    {
        /// <summary>
        /// Mappt eine Auflistung von <see cref="Folders"/> zu einer Auflistung von <see cref="FolderDto"/>.
        /// </summary>
        /// <param name="folders">Die Auflistung von Ordnern, die gemappt werden soll.</param>
        /// <returns>Eine Auflistung von <see cref="FolderDto"/>-Objekten.</returns>
        public static IEnumerable<FolderDto> MapToFolderDto(this IEnumerable<Folders> folders)
        {
            return folders.Select(f => (FolderDto)f);
        }

        /// <summary>
        /// Mappt eine Auflistung von <see cref="FolderDto"/> zu einer Auflistung von <see cref="Folders"/>.
        /// </summary>
        /// <param name="folders">Die Auflistung von Ordner-Datenübertragungsobjekten, die gemappt werden soll.</param>
        /// <returns>Eine Auflistung von <see cref="Folders"/>-Objekten.</returns>
        public static IEnumerable<Folders> MapToFolders(this IEnumerable<FolderDto> folders)
        {
            return folders.Select(f => (Folders)f);
        }
    }
}
