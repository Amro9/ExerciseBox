using exerciseBox.Application.Infrastructur.Models;
using MediatR;

namespace exerciseBox.Application.UseCases.Schools.Commands;

public class CreateSchool : IRequest<SchoolDto>
{
    public SchoolDto School { get; set; }
}
