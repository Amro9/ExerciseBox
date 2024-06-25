using exerciseBox.Application.Abtraction.Extensions;
using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Teacher.Queries;
using MediatR;

namespace exerciseBox.Application.UseCases.Teacher.QueryHandlers;

public class GetTeacherWithPasswordValidationHandler : IRequestHandler<GetTeacherWithPasswordValidation, TeacherDto>
{
    private readonly ITeacherRepository _teacherRepository;
    public GetTeacherWithPasswordValidationHandler(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    public async Task<TeacherDto> Handle(GetTeacherWithPasswordValidation request, CancellationToken cancellationToken)
    {
        var teacher = await _teacherRepository.ReadByEmailAsync(request.Email);
        if (teacher == null)
        {
            return null;
        }

        if (!request.Password.VerifyPassword(teacher.Password))
        {
            throw new UnauthorizedAccessException("Invalid password");
        }

        return teacher;
    }
}
