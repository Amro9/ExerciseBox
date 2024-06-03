using exerciseBox.Application.Abtraction.Models;
using MediatR;

namespace exerciseBox.Application.UseCases.Teacher.Queries;

public class GetTeacherByEmail : IRequest<TeacherDto>
{
    public string Email { get; set; }
}
