using exerciseBox.Application.Abtraction.Models;
using MediatR;

namespace exerciseBox.Application.UseCases.SchoolBranche.Queries
{
    /// <summary>
    /// Eine Anforderungsklasse zur Abfrage aller Schulzweige.
    /// </summary>
    public class GetAllSchoolBranches : IRequest<IEnumerable<SchoolBrancheDto>>
    {
        /// <summary>
        /// Konstruktor für die Anforderung zur Abfrage aller Schulzweige.
        /// </summary>
        public GetAllSchoolBranches()
        {
        }
    }
}
