using exerciseBox.Application.Abtraction.Extensions;
using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Schools.Queries;
using MediatR;

namespace exerciseBox.Application.UseCases.Schools.QueryHandlers;

internal class GetAllSchoolHandler : IRequestHandler<GetAllSchools, IEnumerable<SchoolDto>>
{
    private readonly ISchoolRepository _schoolRepository;

    public GetAllSchoolHandler(ISchoolRepository schoolRepository)
    {
        _schoolRepository = schoolRepository;
    }
     
    public async Task<IEnumerable<SchoolDto>> Handle(GetAllSchools request, CancellationToken cancellationToken)
    {
        var schools = await _schoolRepository.Read();
        return schools.MapToSchoolDto();
    }
}
