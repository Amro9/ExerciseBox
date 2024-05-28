using exerciseBox.Application.Abtraction.Models;
using MediatR;

namespace exerciseBox.Application.UseCases.Teachers.Queries;

public class GetAllTeachers : IRequest<IEnumerable<TeacherDto>>
{

}
