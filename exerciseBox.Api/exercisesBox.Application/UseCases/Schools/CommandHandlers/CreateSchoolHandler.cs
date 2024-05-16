using exercisesBox.Application.Infrastruktur.Repositories;
using exercisesBox.Application.UseCases.Schools.Commands;
using exercisesBox.Domain.Entities;
using MediatR;

namespace exercisesBox.Application.UseCases.Schools.CommandHandlers;

public class CreateSchoolHandler : IRequestHandler<CreateSchool, School>
{
    private readonly ISchoolRepository _schoolRepository;

    public CreateSchoolHandler(ISchoolRepository schoolTypesRepository)
    {
        _schoolRepository = schoolTypesRepository;
    }

    public async Task<School> Handle(CreateSchool request, CancellationToken cancellationToken)
    {
        var school = await _schoolRepository.Create(request.School);
        return school;
    }
}
