using exerciseBox.Application.Abtraction.Extensions;
using exerciseBox.Application.Abtraction.Models;
using exerciseBox.Application.Abtraction.Repositories;
using exerciseBox.Application.UseCases.TeacherCases.Queries;
using MediatR;

namespace exerciseBox.Application.UseCases.TeacherCases.QueryHandlers;

public class GetAllTeachersHandler : IRequestHandler<GetAllTeachers, IEnumerable<TeacherDto>>
{
    private readonly ITeacherRepository _teacherRepository;
    public GetAllTeachersHandler(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    public async Task<IEnumerable<TeacherDto>> Handle(GetAllTeachers request, CancellationToken cancellationToken)
    {
        var teachers = await _teacherRepository.Read();
        return teachers.MapToTeacherDto();
    }

}
