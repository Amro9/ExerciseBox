using exerciseBox.Application.Abtraction.Extensions;
using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Schools.Queries;
using exerciseBox.Application.UseCases.Teacher.Queries;
using exerciseBox.Domain.Entities;
using MediatR;

namespace exerciseBox.Application.UseCases.Schools.QueryHandlers;

public class GetSchoolWithPasswordValidationHandler : IRequestHandler<GetSchoolWithPasswordValidation, SchoolDto>
{
    private readonly ISchoolRepository _schoolRepository;

    public GetSchoolWithPasswordValidationHandler(ISchoolRepository schoolRepository)
    {
        _schoolRepository = schoolRepository;
    }
    public async Task<SchoolDto> Handle(GetSchoolWithPasswordValidation request, CancellationToken cancellationToken)
    {
        var school = await _schoolRepository.ReadByEmail(request.SchoolId);

        if (school == null)
        {
            return null;
        }

        if (!request.Password.VerifyPassword(school.Password))
        {
            throw new UnauthorizedAccessException("Invalid password");
        }

        return school;
    }
}
