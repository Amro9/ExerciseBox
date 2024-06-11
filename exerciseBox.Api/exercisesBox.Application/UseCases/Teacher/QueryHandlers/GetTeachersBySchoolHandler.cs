using exerciseBox.Application.Abtraction.Extensions;
using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.Teacher.Queries;
using MediatR;

namespace exerciseBox.Application.UseCases.Teacher.QueryHandlers;

public class GetTeachersBySchoolHandler : IRequestHandler<GetTeachersBySchool, IEnumerable<TeacherDto>>
{
    private readonly ITeacherRepository _teacherRepository;

    public GetTeachersBySchoolHandler(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    public async Task<IEnumerable<TeacherDto>> Handle(GetTeachersBySchool request, CancellationToken cancellationToken)
    {
        var teachers = await _teacherRepository.ReadBySchoolIdAsync(request.SchoolId);
        return teachers.MapToTeacherDto();
    }
}
