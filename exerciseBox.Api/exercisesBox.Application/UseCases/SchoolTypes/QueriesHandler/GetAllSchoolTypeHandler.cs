using exerciseBox.Application.Abtraction.Extensions;
using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.SchoolTypes.Queries;
using MediatR;

namespace exerciseBox.Application.UseCases.SchoolTypes.QueriesHandler;

public class GetAllSchoolTypeHandler : IRequestHandler<GetAllSchoolTypes, IEnumerable<SchoolTypeDto>>
{
    private readonly ISchoolTypeRepository _schoolTypeRepository;

    public GetAllSchoolTypeHandler(ISchoolTypeRepository schoolTypeRepository)
    {
        _schoolTypeRepository = schoolTypeRepository;
    }
    public async Task<IEnumerable<SchoolTypeDto>> Handle(GetAllSchoolTypes request, CancellationToken cancellationToken)
    {
        var schoolTypes = await _schoolTypeRepository.ReadAsync();
        return schoolTypes.MapToSchoolTypeDtos();
    }
}
