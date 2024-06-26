using exerciseBox.Application.Abtraction.Models;
using MediatR;

namespace exerciseBox.Application.UseCases.Schools.Queries
{
    /// <summary>
    /// Query zur Abfrage aller Schulen.
    /// </summary>
    public class GetAllSchools : IRequest<IEnumerable<SchoolDto>>
    {

    }
}
