using exerciseBox.Application.Abtraction.Extensions;
using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.SchoolTypes.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace exerciseBox.Application.UseCases.SchoolTypes.QueriesHandler
{
    /// <summary>
    /// Query-Handler zur Abfrage aller Schularten.
    /// </summary>
    public class GetAllSchoolTypeHandler : IRequestHandler<GetAllSchoolTypes, IEnumerable<SchoolTypeDto>>
    {
        private readonly ISchoolTypeRepository _schoolTypeRepository;

        /// <summary>
        /// Konstruktor für den GetAllSchoolTypeHandler.
        /// </summary>
        /// <param name="schoolTypeRepository">Das Repository, das für die Datenbankoperationen mit Schularten verwendet wird.</param>
        public GetAllSchoolTypeHandler(ISchoolTypeRepository schoolTypeRepository)
        {
            _schoolTypeRepository = schoolTypeRepository;
        }

        /// <summary>
        /// Verarbeitet den Query zur Abfrage aller Schularten.
        /// </summary>
        /// <param name="request">Der Query zur Abfrage aller Schularten.</param>
        /// <param name="cancellationToken">Das Abbruchtoken.</param>
        /// <returns>Eine Liste von SchoolTypeDto-Objekten, die die abgefragten Schularten darstellen.</returns>
        public async Task<IEnumerable<SchoolTypeDto>> Handle(GetAllSchoolTypes request, CancellationToken cancellationToken)
        {
            // Alle Schularten aus der Datenbank abfragen
            var schoolTypes = await _schoolTypeRepository.ReadAsync();
            return schoolTypes.MapToSchoolTypeDtos();
        }
    }
}
