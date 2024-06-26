using exerciseBox.Application.Abtraction.Models;
using MediatR;

namespace exerciseBox.Application.UseCases.Teacher.Queries
{
    /// <summary>
    /// Anfrageklasse zur Validierung eines Lehrers anhand von E-Mail und Passwort.
    /// Implementiert das MediatR IRequest-Interface und gibt ein TeacherDto zurück.
    /// </summary>
    public class GetTeacherWithPasswordValidation : IRequest<TeacherDto>
    {
        /// <summary>
        /// Die E-Mail-Adresse des Lehrers zur Validierung.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Das Passwort des Lehrers zur Validierung.
        /// </summary>
        public string Password { get; set; }
    }
}
