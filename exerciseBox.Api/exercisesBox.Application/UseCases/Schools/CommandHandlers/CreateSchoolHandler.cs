using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Schools.Commands;
using MediatR;

namespace exerciseBox.Application.UseCases.Schools.CommandHandlers;

public class CreateSchoolHandler : IRequestHandler<CreateSchool, SchoolDto>
{
    private readonly ISchoolRepository _schoolRepository;

    public CreateSchoolHandler(ISchoolRepository schoolTypesRepository)
    {
        _schoolRepository = schoolTypesRepository;
    }

    public async Task<SchoolDto> Handle(CreateSchool request, CancellationToken cancellationToken)
    {
        var school = await _schoolRepository.CreateAsync(request.School);
        return school;
    }
}
