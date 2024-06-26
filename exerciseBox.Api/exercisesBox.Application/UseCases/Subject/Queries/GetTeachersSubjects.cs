using exerciseBox.Application.Abtraction.Models;
using MediatR;

namespace exerciseBox.Application.UseCases.Subject.Queries
{
    /// <summary>
    /// Anfrageklasse zur Abfrage der Fächer eines Lehrers.
    /// Implementiert das MediatR IRequest-Interface und gibt eine Liste von SubjectDto-Objekten zurück.
    /// </summary>
    public class GetTeachersSubjects : IRequest<IEnumerable<SubjectDto>>
    {
        /// <summary>
        /// Die ID des Lehrers, für den die Fächer abgefragt werden sollen.
        /// </summary>
        public string TeacherId { get; set; }
    }
}
