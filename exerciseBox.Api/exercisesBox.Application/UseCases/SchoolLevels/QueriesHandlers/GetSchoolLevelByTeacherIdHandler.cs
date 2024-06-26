using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.SchoolLevels.Queries;
using MediatR;

namespace exerciseBox.Application.UseCases.SchoolLevels.QueriesHandlers
{
    /// <summary>
    /// Handler zur Abfrage der Schulstufen anhand der Lehrer-ID.
    /// </summary>
    internal class GetSchoolLevelByTeacherIdHandler : IRequestHandler<GetSchoolLevelsByTeacherId, IEnumerable<int>>
    {
        private readonly ISchoolLevelRepository _schoolLevelRepository;

        public GetSchoolLevelByTeacherIdHandler(ISchoolLevelRepository schoolLevelRepository)
        {
            _schoolLevelRepository = schoolLevelRepository;
        }

        /// <summary>
        /// Behandelt den Query zur Abfrage der Schulstufen anhand der Lehrer-ID.
        /// </summary>
        /// <param name="request">Der Query zur Abfrage der Schulstufen.</param>
        /// <param name="cancellationToken">Das Token zur Abbruchanforderung.</param>
        /// <returns>Eine Liste von Schulstufen-IDs.</returns>
        public async Task<IEnumerable<int>> Handle(GetSchoolLevelsByTeacherId request, CancellationToken cancellationToken)
        {
            return await _schoolLevelRepository.ReadByTeacherId(request.TeacherId);
        }
    }
}
