using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Schools.Queries;
using MediatR;

namespace exerciseBox.Application.UseCases.Schools.QueryHandlers
{
    /// <summary>
    /// Handler zur Abfrage einer Schule anhand ihrer ID.
    /// </summary>
    public class GetSchoolByIdHandler : IRequestHandler<GetSchoolById, SchoolDto>
    {
        private readonly ISchoolRepository _schoolRepository;

        /// <summary>
        /// Konstruktor für den GetSchoolByIdHandler.
        /// </summary>
        /// <param name="schoolRepository">Das Repository, das für die Datenbankoperationen mit Schulen verwendet wird.</param>
        public GetSchoolByIdHandler(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        /// <summary>
        /// Verarbeitet den Query zur Abfrage einer Schule anhand ihrer ID.
        /// </summary>
        /// <param name="request">Der Query zur Abfrage der Schule.</param>
        /// <param name="cancellationToken">Das Abbruchtoken.</param>
        /// <returns>Das SchoolDto-Objekt der abgefragten Schule oder null, falls die Schule nicht gefunden wurde.</returns>
        public async Task<SchoolDto> Handle(GetSchoolById request, CancellationToken cancellationToken)
        {
            var school = await _schoolRepository.ReadByIdAsync(request.Email);
            return school;
        }
    }
}
