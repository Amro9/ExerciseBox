using exerciseBox.Application.Abtraction.Models;
using MediatR;

namespace exerciseBox.Application.UseCases.Schools.Queries
{
    /// <summary>
    /// Query zur Abfrage einer Schule anhand ihrer E-Mail-Adresse.
    /// </summary>
    public class GetSchoolById : IRequest<SchoolDto>
    {
        /// <summary>
        /// Die E-Mail-Adresse der abzufragenden Schule.
        /// </summary>
        public string Email { get; set; }
    }
}
