using exerciseBox.Application.Infrastructur.Models;
using MediatR;

namespace exerciseBox.Application.UseCases.TeacherCases.Queries;

public class GetAllTeachers : IRequest<IEnumerable<TeacherDto>>
{

}
