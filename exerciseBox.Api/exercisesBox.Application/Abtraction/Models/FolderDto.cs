using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Models
{
    /// <summary>
    /// Repräsentiert ein Datenübertragungsobjekt für einen Ordner.
    /// </summary>
    public class FolderDto
    {
        /// <summary>
        /// Die eindeutige Kennung des Ordners.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Der Name des Ordners.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Die Kennung des zugehörigen Fachs.
        /// </summary>
        public string SubjectId { get; set; }

        /// <summary>
        /// Das Datenübertragungsobjekt des zugehörigen Fachs.
        /// </summary>
        public SubjectDto Subject { get; set; }

        /// <summary>
        /// Gibt an, ob es sich um einen Erstellungsordner handelt.
        /// </summary>
        public bool IsCreationFolder { get; set; }

        /// <summary>
        /// Implizite Konvertierung von <see cref="Folders"/> zu <see cref="FolderDto"/>.
        /// </summary>
        /// <param name="folder">Das <see cref="Folders"/>-Objekt, das konvertiert werden soll.</param>
        public static implicit operator FolderDto(Folders folder)
        {
            if (folder == null)
            {
                return null;
            }
            return new FolderDto
            {
                Id = folder.Id,
                Name = folder.Name,
                SubjectId = folder.Subject,
                Subject = folder.SubjectNavigation,
                IsCreationFolder = folder.IsCreationFolder
            };
        }

        /// <summary>
        /// Implizite Konvertierung von <see cref="FolderDto"/> zu <see cref="Folders"/>.
        /// </summary>
        /// <param name="folder">Das <see cref="FolderDto"/>-Objekt, das konvertiert werden soll.</param>
        public static implicit operator Folders(FolderDto folder)
        {
            return new Folders
            {
                Id = folder.Id,
                Name = folder.Name,
                Subject = folder.SubjectId,
                IsCreationFolder = folder.IsCreationFolder
            };
        }
    }
}
