using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Models
{
    /// <summary>
    /// Datenübertragungsobjekt für Schulen.
    /// </summary>
    public class SchoolDto
    {
        /// <summary>
        /// Ruft den Schultyp ab oder legt diesen fest.
        /// </summary>
        public SchoolTypeDto SchoolType { get; set; }

        /// <summary>
        /// Ruft die E-Mail-Adresse der Schule ab oder legt diese fest.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Ruft den Namen der Schule ab oder legt diesen fest.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Konvertiert ein Schools-Objekt implizit in ein SchoolDto-Objekt.
        /// </summary>
        public static implicit operator SchoolDto(Schools school)
        {
            if (school is null)
                return null;

            return new SchoolDto
            {
                Name = school.Name,
                SchoolType = school.SchoolTypeNavigation
            };
        }

        /// <summary>
        /// Konvertiert ein SchoolDto-Objekt implizit in ein Schools-Objekt.
        /// </summary>
        public static implicit operator Schools(SchoolDto school)
        {
            if (school is null)
                return null;

            return new Schools
            {
                Name = school.Name,
                SchoolTypeNavigation = school.SchoolType
            };
        }
    }
}
