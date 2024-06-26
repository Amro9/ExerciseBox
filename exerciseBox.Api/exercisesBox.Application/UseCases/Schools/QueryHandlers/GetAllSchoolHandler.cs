using exerciseBox.Application.Abtraction.Extensions;
using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Schools.Queries;
using MediatR;

namespace exerciseBox.Application.UseCases.Schools.QueryHandlers
{
    /// <summary>
    /// Handler zur Abfrage aller Schulen.
    /// </summary>
    internal class GetAllSchoolHandler : IRequestHandler<GetAllSchools, IEnumerable<SchoolDto>>
    {
        private readonly ISchoolRepository _schoolRepository;

        /// <summary>
        /// Konstruktor für den GetAllSchoolHandler.
        /// </summary>
        /// <param name="schoolRepository">Das Repository, das für die Datenbankoperationen mit Schulen verwendet wird.</param>
        public GetAllSchoolHandler(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        /// <summary>
        /// Verarbeitet den Query zur Abfrage aller Schulen.
        /// </summary>
        /// <param name="request">Der Query zur Abfrage aller Schulen.</param>
        /// <param name="cancellationToken">Das Abbruchtoken.</param>
        /// <returns>Eine Liste von SchoolDto-Objekten, die alle abgefragten Schulen darstellen.</returns>
        public async Task<IEnumerable<SchoolDto>> Handle(GetAllSchools request, CancellationToken cancellationToken)
        {
            var schools = await _schoolRepository.ReadAsync();
            return schools.MapToSchoolDto();
        }
    }
}
