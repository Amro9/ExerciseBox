using exerciseBox.Domain.Entities;
using System.Reflection.Metadata.Ecma335;

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
        public string Id { get; set; }

        /// <summary>
        /// Ruft die Beschreibung des Schwierigkeitsgrads ab oder legt diese fest.
        /// </summary>
        public string Description { get; set; }

        public static implicit operator DifficultyLevelDto(QuestionDifficultyLevels v)
        {
            if(v == null)
            {
                return null;
            }
            return new DifficultyLevelDto
            {
                Id = v.Id,
                Description = v.Description
            };
        }
    }
}
