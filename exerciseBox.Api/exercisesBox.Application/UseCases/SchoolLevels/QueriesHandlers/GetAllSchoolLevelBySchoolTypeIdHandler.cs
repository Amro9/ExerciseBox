using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.SchoolLevels.Queries;
using MediatR;

namespace exerciseBox.Application.UseCases.SchoolLevels.QueriesHandlers
{
    /// <summary>
    /// Handler zur Abfrage aller Schulstufen anhand eines Schultyps.
    /// </summary>
    public class GetAllSchoolLevelBySchoolTypeIdHandler : IRequestHandler<GetSchoolLevelsBySchoolTypeId, IEnumerable<int>>
    {
        private readonly ISchoolLevelRepository _schoolLevelRepository;

        public GetAllSchoolLevelBySchoolTypeIdHandler(ISchoolLevelRepository schoolLevelRepository)
        {
            _schoolLevelRepository = schoolLevelRepository;
        }

        /// <summary>
        /// Behandelt den Query zur Abfrage aller Schulstufen anhand eines Schultyps.
        /// </summary>
        /// <param name="request">Der Query zur Abfrage aller Schulstufen anhand eines Schultyps.</param>
        /// <param name="cancellationToken">Das Token zur Abbruchanforderung.</param>
        /// <returns>Eine Liste von Schulstufen-IDs.</returns>
        public async Task<IEnumerable<int>> Handle(GetSchoolLevelsBySchoolTypeId request, CancellationToken cancellationToken)
        {
            return await _schoolLevelRepository.ReadBySchoolTypeId(request.SchoolTypeId);
        }
    }
}
