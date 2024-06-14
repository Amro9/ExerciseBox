using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Models
{
    /// <summary>
    /// Datenübertragungsobjekt für Schultypen.
    /// </summary>
    public class SchoolTypeDto
    {
        /// <summary>
        /// Ruft die ID des Schultyps ab oder legt diese fest.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Ruft die Beschreibung des Schultyps ab oder legt diese fest.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Konvertiert ein SchoolTypes-Objekt implizit in ein SchoolTypeDto-Objekt.
        /// </summary>
        public static implicit operator SchoolTypeDto(SchoolTypes schoolType)
        {
            if(schoolType == null)
            {
                return null;
            }
            return new SchoolTypeDto
            {
                Id = schoolType.Id,
                Description = schoolType.Name
            };
        }

        /// <summary>
        /// Konvertiert ein SchoolTypeDto-Objekt implizit in ein SchoolTypes-Objekt.
        /// </summary>
        public static implicit operator SchoolTypes(SchoolTypeDto schoolType)
        {
            return new SchoolTypes
            {
                Id = schoolType.Id,
                Name = schoolType.Description
            };
        }
    }
}
