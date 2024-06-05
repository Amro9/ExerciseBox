using exerciseBox.Application.Abtraction.Models;
using MediatR;

namespace exerciseBox.Application.UseCases.Schools.Queries;

public class GetSchoolById : IRequest<SchoolDto>
{
    public string Email { get; set; }
}
