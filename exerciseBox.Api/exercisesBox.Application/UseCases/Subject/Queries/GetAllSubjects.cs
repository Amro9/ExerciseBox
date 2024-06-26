using exerciseBox.Application.Abtraction.Models;
using MediatR;

namespace exerciseBox.Application.UseCases.Subject.Queries
{
    /// <summary>
    /// Anfrageklasse zur Abfrage aller Fächer.
    /// Implementiert das MediatR IRequest-Interface und gibt eine Liste von SubjectDto-Objekten zurück.
    /// </summary>
    public class GetAllSubjects : IRequest<IEnumerable<SubjectDto>>
    {
        // Keine zusätzlichen Eigenschaften erforderlich.
    }
}
