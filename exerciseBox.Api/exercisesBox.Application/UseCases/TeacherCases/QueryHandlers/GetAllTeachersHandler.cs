using exerciseBox.Application.Infrastructur.Extensions;
using exerciseBox.Application.Infrastructur.Models;
using exerciseBox.Application.Infrastructur.Repositories;
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
