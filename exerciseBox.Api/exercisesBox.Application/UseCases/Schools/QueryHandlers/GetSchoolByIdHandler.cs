using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Schools.Queries;
using MediatR;

namespace exerciseBox.Application.UseCases.Schools.QueryHandlers;

public class GetSchoolByIdHandler : IRequestHandler<GetSchoolById, SchoolDto>
{
    private readonly ISchoolRepository _schoolRepository;

    public GetSchoolByIdHandler(ISchoolRepository schoolRepository)
    {
        _schoolRepository = schoolRepository;
    }

    public async Task<SchoolDto> Handle(GetSchoolById request, CancellationToken cancellationToken)
    {
        var school = await _schoolRepository.ReadById(request.Id);
        return school;
    }
}
