using exerciseBox.Application.Abtraction.Models;
using MediatR;
using System.Collections.Generic;

namespace exerciseBox.Application.UseCases.Teachers.Queries
{
    /// <summary>
    /// Anfrageklasse zur Abfrage aller Lehrer.
    /// Implementiert das MediatR IRequest-Interface und gibt eine Liste von TeacherDto-Objekten zurück.
    /// </summary>
    public class GetAllTeachers : IRequest<IEnumerable<TeacherDto>>
    {
        // Keine zusätzlichen Eigenschaften erforderlich.
    }
}
