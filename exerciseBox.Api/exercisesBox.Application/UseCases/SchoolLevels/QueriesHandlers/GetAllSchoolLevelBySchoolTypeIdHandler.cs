using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.SchoolLevels.Queries;
using MediatR;

namespace exerciseBox.Application.UseCases.SchoolLevels.QueriesHandlers
{
    public class GetAllSchoolLevelBySchoolTypeIdHandler : IRequestHandler<GetSchoolLevelsBySchoolTypeId, IEnumerable<int>>
    {
        private readonly ISchoolLevelRepository _schoolLevelRepository;
        public GetAllSchoolLevelBySchoolTypeIdHandler(ISchoolLevelRepository schoolLevelRepository )
        {
            _schoolLevelRepository = schoolLevelRepository;
        }

        public async Task<IEnumerable<int>> Handle(GetSchoolLevelsBySchoolTypeId request, CancellationToken cancellationToken)
        {
            return await _schoolLevelRepository.ReadBySchoolTypeId(request.SchoolTypeId);
        }
    }
}
