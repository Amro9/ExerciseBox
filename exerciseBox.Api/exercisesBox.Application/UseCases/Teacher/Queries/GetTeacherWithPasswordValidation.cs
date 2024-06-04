using exerciseBox.Application.Abtraction.Models;
using MediatR;

namespace exerciseBox.Application.UseCases.Teacher.Queries;

public class GetTeacherWithPasswordValidation : IRequest<TeacherDto>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
