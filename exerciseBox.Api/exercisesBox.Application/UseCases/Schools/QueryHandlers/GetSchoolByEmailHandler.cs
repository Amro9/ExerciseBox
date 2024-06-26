using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Schools.Queries;
using MediatR;

namespace exerciseBox.Application.UseCases.Schools.QueryHandlers
{
    /// <summary>
    /// Handler zur Abfrage einer Schule anhand ihrer E-Mail-Adresse.
    /// </summary>
    public class GetSchoolByEmailHandler : IRequestHandler<GetSchoolByEmail, SchoolDto>
    {
        private readonly ISchoolRepository _schoolRepository;

        /// <summary>
        /// Konstruktor für den GetSchoolByEmailHandler.
        /// </summary>
        /// <param name="schoolRepository">Das Repository, das für die Datenbankoperationen mit Schulen verwendet wird.</param>
        public GetSchoolByEmailHandler(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        /// <summary>
        /// Verarbeitet den Query zur Abfrage einer Schule anhand ihrer E-Mail-Adresse.
        /// </summary>
        /// <param name="request">Der Query zur Abfrage der Schule.</param>
        /// <param name="cancellationToken">Das Abbruchtoken.</param>
        /// <returns>Das SchoolDto-Objekt der abgefragten Schule oder null, falls die Schule nicht gefunden wurde.</returns>
        public async Task<SchoolDto> Handle(GetSchoolByEmail request, CancellationToken cancellationToken)
        {
            var school = await _schoolRepository.ReadByEmail(request.Email);
            return school;
        }
    }
}
