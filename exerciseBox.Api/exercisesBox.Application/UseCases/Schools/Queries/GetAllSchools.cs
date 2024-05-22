using exerciseBox.Application.Infrastructur.Models;
using MediatR;

namespace exerciseBox.Application.UseCases.Schools.Queries;

public class GetAllSchools : IRequest<IEnumerable<SchoolDto>>
{

}
