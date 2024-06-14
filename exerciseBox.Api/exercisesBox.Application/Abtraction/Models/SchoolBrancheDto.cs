using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Models
{
    /// <summary>
    /// Datenübertragungsobjekt für Schulfächer.
    /// </summary>
    public class SchoolBrancheDto
    {
        /// <summary>
        /// Ruft die ID des Schulfachs ab oder legt diese fest.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Ruft den Namen des Schulfachs ab oder legt diesen fest.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Konvertiert ein SchoolBranches-Objekt implizit in ein SchoolBrancheDto-Objekt.
        /// </summary>
        public static implicit operator SchoolBrancheDto(SchoolBranches schoolBranche)
        {
            if (schoolBranche is null)
                return null;

            return new SchoolBrancheDto
            {
                Id = Guid.Parse(schoolBranche.Id),
                Name = schoolBranche.Name
            };
        }

        /// <summary>
        /// Konvertiert ein SchoolBrancheDto-Objekt implizit in ein SchoolBranches-Objekt.
        /// </summary>
        public static implicit operator SchoolBranches(SchoolBrancheDto schoolBranche)
        {
            if (schoolBranche is null)
                return null;

            return new SchoolBranches
            {
                Id = schoolBranche.Id.ToString(),
                Name = schoolBranche.Name
            };
        }
    }
}
