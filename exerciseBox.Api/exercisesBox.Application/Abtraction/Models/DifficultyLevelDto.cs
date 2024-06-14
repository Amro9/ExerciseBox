namespace exerciseBox.Application.Abtraction.Models
{
    /// <summary>
    /// Datenübertragungsobjekt für Schwierigkeitsgrade.
    /// </summary>
    public class DifficultyLevelDto
    {
        /// <summary>
        /// Ruft die ID des Schwierigkeitsgrads ab oder legt diese fest.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Ruft die Beschreibung des Schwierigkeitsgrads ab oder legt diese fest.
        /// </summary>
        public string Description { get; set; }
    }
}
