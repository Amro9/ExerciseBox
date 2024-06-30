using exerciseBox.Application.Abtraction.Models;
using MediatR;

namespace exerciseBox.Application.UseCases.Subject.Queries
{
    /// <summary>
    /// Abfrage für die Fächer eines Zweiges.
    /// </summary>
    public class GetBranchSubjects : IRequest<IEnumerable<SubjectDto>>
    {
        public string BranchId { get; set; }
    }
}
