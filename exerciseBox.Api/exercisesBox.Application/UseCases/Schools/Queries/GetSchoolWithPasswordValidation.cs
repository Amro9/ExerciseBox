using exerciseBox.Application.Abtraction.Models;
using MediatR;

namespace exerciseBox.Application.UseCases.Schools.Queries
{
    /// <summary>
    /// Query zur Validierung einer Schule anhand ihrer E-Mail-Adresse und Passwort.
    /// </summary>
    public class GetSchoolWithPasswordValidation : IRequest<SchoolDto>
    {
        /// <summary>
        /// Die E-Mail-Adresse der Schule.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Das Passwort der Schule.
        /// </summary>
        public string Password { get; set; }
    }
}
