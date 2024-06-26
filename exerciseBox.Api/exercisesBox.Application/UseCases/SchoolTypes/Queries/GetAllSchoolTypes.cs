using exerciseBox.Application.Abtraction.Models;
using MediatR;
using System.Collections.Generic;

namespace exerciseBox.Application.UseCases.SchoolTypes.Queries
{
    /// <summary>
    /// Anfrageklasse zur Abfrage aller Schularten.
    /// Implementiert das MediatR IRequest-Interface und gibt eine Liste von SchoolTypeDto-Objekten zurück.
    /// </summary>
    public class GetAllSchoolTypes : IRequest<IEnumerable<SchoolTypeDto>>
    {
        // Keine zusätzlichen Eigenschaften erforderlich.
    }
}
