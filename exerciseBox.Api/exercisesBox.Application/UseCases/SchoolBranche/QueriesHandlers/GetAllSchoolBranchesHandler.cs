using exerciseBox.Application.Abtraction.Extensions;
using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.SchoolBranche.Queries;
using MediatR;

namespace exerciseBox.Application.UseCases.SchoolBranche.QueriesHandlers
{
    /// <summary>
    /// Handler zur Bearbeitung der Abfrage aller Schulzweige.
    /// </summary>
    public class GetAllSchoolBranchesHandler : IRequestHandler<GetAllSchoolBranches, IEnumerable<SchoolBrancheDto>>
    {
        private readonly ISchoolBranchesRepository _schoolBranchesRepository;

        /// <summary>
        /// Konstruktor für die Initialisierung eines neuen Handlers zur Abfrage aller Schulzweige.
        /// </summary>
        /// <param name="schoolBranchesRepository">Das Repository für Schulzweige.</param>
        public GetAllSchoolBranchesHandler(ISchoolBranchesRepository schoolBranchesRepository)
        {
            _schoolBranchesRepository = schoolBranchesRepository;
        }

        /// <summary>
        /// Behandelt die Abfrage nach allen Schulzweigen.
        /// </summary>
        /// <param name="request">Die Abfrage zur Abfrage aller Schulzweige.</param>
        /// <param name="cancellationToken">Das Token zur Anforderungsabbruchüberwachung.</param>
        /// <returns>Eine Auflistung von DTOs der abgerufenen Schulzweige.</returns>
        public async Task<IEnumerable<SchoolBrancheDto>> Handle(GetAllSchoolBranches request, CancellationToken cancellationToken)
        {
            var schoolBranches = await _schoolBranchesRepository.ReadAsync();
            return SchoolBranchesMappingExtension.MapToDto(schoolBranches);
        }
    }
}
