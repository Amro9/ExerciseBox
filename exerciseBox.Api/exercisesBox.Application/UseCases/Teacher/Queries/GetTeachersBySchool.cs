using exerciseBox.Application.Abtraction.Models;
using MediatR;

namespace exerciseBox.Application.UseCases.Teacher.Queries;

public class GetTeachersBySchool : IRequest<IEnumerable<TeacherDto>>
{
    public string SchoolId { get; set; }
}
