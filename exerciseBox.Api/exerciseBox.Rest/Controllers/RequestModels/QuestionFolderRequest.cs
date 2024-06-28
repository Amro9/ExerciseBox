using System;

namespace exerciseBox.Rest.Controllers.RequestModels
{
    /// <summary>
    /// Modell für die Anfrage zum Speichern einer Frage in einem Ordner.
    /// </summary>
    public class QuestionFolderRequest
    {
        /// <summary>
        /// Die ID der Verbindung.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Die ID des Ordners.
        /// </summary>
        public string FolderId { get; set; }

        /// <summary>
        /// Die ID der Frage.
        /// </summary>
        public string QuestionId { get; set; }

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="QuestionFolderRequest"/> Klasse.
        /// Setzt die <see cref="Id"/> auf eine neue Guid.
        /// </summary>
        public QuestionFolderRequest()
        {
            Id = Guid.NewGuid();
        }
    }
}
