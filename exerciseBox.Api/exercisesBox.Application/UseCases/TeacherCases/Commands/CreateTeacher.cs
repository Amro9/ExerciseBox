using exerciseBox.Domain.Entities;
using MediatR;

namespace exerciseBox.Application.UseCases.TeacherCases.Commands;

public class CreateTeacher : IRequest<Teachers>
{
    public Teachers Teacher { get; set; }
}
