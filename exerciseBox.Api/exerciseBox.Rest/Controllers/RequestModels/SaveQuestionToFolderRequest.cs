using System;

namespace exerciseBox.Rest.Controllers.RequestModels
{
    /// <summary>
    /// Modell für die Anfrage zum Speichern einer Frage in einem Ordner.
    /// </summary>
    public class SaveQuestionToFolderRequest
    {
        /// <summary>
        /// Die ID der Verbindung.
        /// </summary>
        public Guid JunctionId { get; set; }

        /// <summary>
        /// Die ID des Ordners.
        /// </summary>
        public string FolderId { get; set; }

        /// <summary>
        /// Die ID der Frage.
        /// </summary>
        public string QuestionId { get; set; }

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="SaveQuestionToFolderRequest"/> Klasse.
        /// Setzt die <see cref="JunctionId"/> auf eine neue Guid.
        /// </summary>
        public SaveQuestionToFolderRequest()
        {
            JunctionId = Guid.NewGuid();
        }
    }
}
