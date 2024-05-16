using MediatR;
using exercisesBox.Domain.Entities;

namespace exercisesBox.Application.UseCases.Schools.Commands;

public class CreateSchool : IRequest<School>
{
    public School School { get; set; }
}
