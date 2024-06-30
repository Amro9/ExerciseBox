using exerciseBox.Application.Abtraction.Models;
using MediatR;

namespace exerciseBox.Application.UseCases.Schools.Queries
{
    /// <summary>
    /// Abfrage zum Abrufen der Zweige einer Schule.
    /// </summary>
    public class GetBranchesOfSchool : IRequest<IEnumerable<SchoolBrancheDto>>
    {
        public string SchoolId { get; set; }
    }
}
