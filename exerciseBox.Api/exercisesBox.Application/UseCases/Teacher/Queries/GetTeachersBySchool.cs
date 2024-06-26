using exerciseBox.Application.Abtraction.Models;
using MediatR;
using System.Collections.Generic;

namespace exerciseBox.Application.UseCases.Teacher.Queries
{
    /// <summary>
    /// Anfrageklasse zur Abfrage von Lehrern anhand der Schul-ID.
    /// Implementiert das MediatR IRequest-Interface und gibt eine Liste von TeacherDto-Objekten zurück.
    /// </summary>
    public class GetTeachersBySchool : IRequest<IEnumerable<TeacherDto>>
    {
        /// <summary>
        /// Die ID der Schule, für die die Lehrer abgefragt werden sollen.
        /// </summary>
        public string SchoolId { get; set; }
    }
}
