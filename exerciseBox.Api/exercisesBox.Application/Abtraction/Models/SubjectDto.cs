
using exerciseBox.Domain.Entities;

namespace exerciseBox.Application.Abtraction.Models
{
    /// <summary>
    /// Datenübertragungsobjekt für Fächer.
    /// </summary>
    public class SubjectDto
    {
        /// <summary>
        /// Ruft die ID des Fachs ab oder legt diese fest.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Ruft den Namen des Fachs ab oder legt diesen fest.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Ruft die Abkürzung des Fachs ab oder legt diese fest.
        /// </summary>
        public string Shortcut { get; set; }

        /// <summary>
        /// Konvertiert ein Subjects-Objekt implizit in ein SubjectDto-Objekt.
        /// </summary>
        public static implicit operator SubjectDto(Subjects subject)
        {
            if(subject == null)
            {
                return null;
            }

            return new SubjectDto
            {
                Id = Guid.Parse(subject.Id),
                Name = subject.Name,
                Shortcut = subject.Shortcut
            };
        }

        /// <summary>
        /// Konvertiert ein SubjectDto-Objekt implizit in ein Subjects-Objekt.
        /// </summary>
        public static implicit operator Subjects(SubjectDto subject)
        {
            return new Subjects
            {
                Id = subject.Id.ToString(),
                Name = subject.Name,
                Shortcut = subject.Shortcut
            };
        }
    }
}
