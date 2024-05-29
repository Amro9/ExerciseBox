using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Schools.Queries;
using MediatR;

namespace exerciseBox.Application.UseCases.Schools.QueryHandlers;

public class GetSchoolByEmailHandler : IRequestHandler<GetSchoolByEmail, SchoolDto>
{
    private readonly ISchoolRepository _schoolRepository;
    public GetSchoolByEmailHandler(ISchoolRepository schoolRepository)
    {
        _schoolRepository = schoolRepository;
    }

    public async Task<SchoolDto> Handle(GetSchoolByEmail request, CancellationToken cancellationToken)
    {
        var school = await _schoolRepository.ReadByEmail(request.Email);
        return school;
    }
}
