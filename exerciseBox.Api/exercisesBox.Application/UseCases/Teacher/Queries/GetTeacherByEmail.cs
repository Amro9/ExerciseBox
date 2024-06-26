using exerciseBox.Application.Abtraction.Models;
using MediatR;

namespace exerciseBox.Application.UseCases.Teacher.Queries
{
    /// <summary>
    /// Anfrageklasse zur Abfrage eines Lehrers anhand der E-Mail-Adresse.
    /// Implementiert das MediatR IRequest-Interface und gibt ein TeacherDto zurück.
    /// </summary>
    public class GetTeacherByEmail : IRequest<TeacherDto>
    {
        /// <summary>
        /// Die E-Mail-Adresse des Lehrers, nach der gesucht wird.
        /// </summary>
        public string Email { get; set; }
    }
}
