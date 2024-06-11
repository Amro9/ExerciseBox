using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Teacher.Queries;
using MediatR;

namespace exerciseBox.Application.UseCases.Teacher.QueryHandlers;

public class GetTeacherByEmailHandler : IRequestHandler<GetTeacherByEmail, TeacherDto>
{
    private readonly ITeacherRepository _teacherRepository;
    public GetTeacherByEmailHandler(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    public async Task<TeacherDto> Handle(GetTeacherByEmail request, CancellationToken cancellationToken)
    {
        var teacher = await _teacherRepository.ReadByEmailAsync(request.Email);
        return teacher;
    }
}
