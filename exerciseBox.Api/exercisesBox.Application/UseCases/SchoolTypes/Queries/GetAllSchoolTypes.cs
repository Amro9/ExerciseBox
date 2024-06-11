using exerciseBox.Application.Abtraction.Models;
using MediatR;

namespace exerciseBox.Application.UseCases.SchoolTypes.Queries;

public class GetAllSchoolTypes : IRequest<IEnumerable<SchoolTypeDto>>
{

}
