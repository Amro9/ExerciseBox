using exerciseBox.Application.Abtraction.Models;
using MediatR;

namespace exerciseBox.Application.UseCases.Teachers.Commands
{
    /// <summary>
    /// Befehlsklasse zur Erstellung eines neuen Lehrers.
    /// Implementiert das MediatR IRequest-Interface und gibt ein TeacherDto zurück.
    /// </summary>
    public class CreateTeacher : IRequest<TeacherDto>
    {
        /// <summary>
        /// Das DTO-Objekt, das die Informationen des zu erstellenden Lehrers enthält.
        /// </summary>
        public TeacherDto Teacher { get; set; }
    }
}
