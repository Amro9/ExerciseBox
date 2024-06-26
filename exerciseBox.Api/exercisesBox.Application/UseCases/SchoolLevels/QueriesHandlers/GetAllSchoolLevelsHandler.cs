using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.SchoolLevels.Queries;
using MediatR;

namespace exerciseBox.Application.UseCases.SchoolLevels.QueriesHandlers
{
    /// <summary>
    /// Handler zur Abfrage aller Schulstufen.
    /// </summary>
    public class GetAllSchoolLevelsHandler : IRequestHandler<GetAllSchoolLevels, IEnumerable<int>>
    {
        private readonly ISchoolLevelRepository _schoolLevelRepository;

        public GetAllSchoolLevelsHandler(ISchoolLevelRepository schoolLevelRepository)
        {
            _schoolLevelRepository = schoolLevelRepository;
        }

        /// <summary>
        /// Behandelt den Query zur Abfrage aller Schulstufen.
        /// </summary>
        /// <param name="request">Der Query zur Abfrage aller Schulstufen.</param>
        /// <param name="cancellationToken">Das Token zur Abbruchanforderung.</param>
        /// <returns>Eine Liste von Schulstufen-IDs.</returns>
        public async Task<IEnumerable<int>> Handle(GetAllSchoolLevels request, CancellationToken cancellationToken)
        {
            return await _schoolLevelRepository.ReadAsync();
        }
    }
}
