using exerciseBox.Domain.Entities;
using MediatR;

namespace exerciseBox.Application.UseCases.Teachers.Commands;

public class CreateTeacher : IRequest<Domain.Entities.Teachers>
{
    public Domain.Entities.Teachers Teacher { get; set; }
}
