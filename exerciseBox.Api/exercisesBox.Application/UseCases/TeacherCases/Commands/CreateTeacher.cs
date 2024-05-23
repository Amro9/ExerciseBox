using exerciseBox.Domain.Entities;
using MediatR;

namespace exerciseBox.Application.UseCases.TeacherCases.Commands;

public class CreateTeacher : IRequest<Teacher>
{
    public Teacher Teacher { get; set; }
}
