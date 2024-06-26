using exerciseBox.Application.Abtraction.Models;
using MediatR;

namespace exerciseBox.Application.UseCases.Schools.Commands
{
    /// <summary>
    /// Command zum Erstellen einer neuen Schule.
    /// </summary>
    public class CreateSchool : IRequest<SchoolDto>
    {
        /// <summary>
        /// Die Informationen zur zu erstellenden Schule.
        /// </summary>
        public SchoolDto School { get; set; }
    }
}
